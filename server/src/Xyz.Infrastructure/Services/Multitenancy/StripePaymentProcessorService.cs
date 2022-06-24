using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Stripe;

using Xyz.Core.Models.Configuration;
using Xyz.Core.Interfaces.Multitenancy;
using Xyz.Core.Models.Multitenancy.Payments;
using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Models.Multitenancy;
using Xyz.Multitenancy.Data;

namespace Xyz.Infrastructure.Services.Multitenancy
{
    public class StripePaymentProcessorService : IPaymentProcessorService
    {
        private readonly ILogger<StripePaymentProcessorService> _logger;
        private readonly IOptions<StripeSettings> _stripeSettings;
        private readonly MultitenancyDbContext _multitenancyDbContext;

        public StripePaymentProcessorService(
            ILogger<StripePaymentProcessorService> logger, 
            IOptions<StripeSettings> stripeSettings,
            MultitenancyDbContext multitenancyDbContext)
        {
            this._logger = logger;
            this._stripeSettings = stripeSettings;
            this._multitenancyDbContext = multitenancyDbContext;
            StripeConfiguration.ApiKey = stripeSettings.Value.SecretKey;
        }

        public async Task<CreatePaymentMethodResponse> CreatePaymentMethod(CreatePaymentMethodRequest request)
        {
            try
            {
                var options = new PaymentMethodCreateOptions
                {
                    Type = "card",
                    Card = new PaymentMethodCardOptions
                    {
                        Token = request.Token
                    }
                };

                var service = new PaymentMethodService();
                var paymentMethod = await service.CreateAsync(options);

                return new CreatePaymentMethodResponse
                {
                    PaymnentMethodId = paymentMethod.Id
                };
            }
            catch (Exception ex)
            {
                var errorMessage = "Error creating new payment method with Stripe API";
                var errorPayload = new { Exception = ex.Message, Request = request };
                this._logger.LogError(errorMessage, errorPayload);
                throw;
            }
            
        }

        public async Task<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest request)
        {
            try
            {
                var options = new CustomerCreateOptions
                {
                    Name = $"{request.FirstName} {request.LastName}",
                    Email = request.Email,
                    Address = new AddressOptions 
                    {
                        Line1 = request.Address,
                        City = request.City,
                        State = request.State,
                        PostalCode = request.Zip    
                    },
                    Source = request.Source
                };
                
                var service = new CustomerService();
                var customer = await service.CreateAsync(options);

                return new CreateCustomerResponse
                {
                    CustomerId = customer.Id,
                    DefaultSourceId = customer.DefaultSourceId,
                };
            }
            catch (Exception ex)
            {
                var errorMessage = "Error creating new customer with Stripe API";
                var errorPayload = new { Exception = ex.Message, Request = request };
                this._logger.LogError(errorMessage, errorPayload);
                throw;
            }
        }

        public async Task<CreateSubscriptionResponse> CreateSubscription(CreateSubscriptionRequest request)
        {
            try
            {
                var options = new SubscriptionCreateOptions
                {
                    Customer = request.CustomerId,
                    Items = new List<SubscriptionItemOptions>
                    {
                        new SubscriptionItemOptions
                        {
                            Plan = request.ExternalPlanId
                        },
                    },
                };

                var service = new SubscriptionService();
                var subscription = await service.CreateAsync(options);

                return new CreateSubscriptionResponse
                {
                    SubscriptionId = subscription.Id
                };
            }
            catch (Exception ex)
            {
                var errorMessage = "Error creating new subscription with Stripe API";
                var errorPayload = new { Exception = ex.Message, Request = request };
                this._logger.LogError(errorMessage, errorPayload);
                throw;
            }
        }
        
        public async Task<object> CancelSubscription(object subscription)
        {
            throw new NotImplementedException();
        }

        public async Task<object> UpdateSubscription(object subscription)
        {
            throw new NotImplementedException();
        }
        
        public async Task<object> ListSubscriptions()
        {
            throw new NotImplementedException();
        }

        public async Task ProcessWebhook<T>(T webhookData)
        {
            try
            {
                Event? stripeEvent = webhookData as Event;

                switch (stripeEvent?.Type)
                {
                    case Events.InvoicePaid:
                        await this._HandleInvoicePaidEvent(stripeEvent);
                        break;
                    case Events.InvoicePaymentFailed:
                        await this._HandleInvoicePaymentFailed(stripeEvent);
                        break;
                    case Events.CustomerSubscriptionDeleted:
                        await this._HandleCustomerSubscriptionDeleted(stripeEvent);
                        break;
                    default:
                        await this._HandleUnhandledEvents(stripeEvent);
                        break;
                }
            }
            catch (Exception ex)
            {
                var errorMessage = "Error processing Strip event webhook from service";
                var errorPayload = new { Exception = ex.Message, Data = webhookData };
                this._logger.LogError(errorMessage, errorPayload);
                throw;
            }
        }

        private async Task _HandleInvoicePaidEvent(Event stripeEvent)
        {
            await this._HandleAndProcessInvoiceFromEvent(stripeEvent);
            return;
        }

        private async Task _HandleInvoicePaymentFailed(Event stripeEvent)
        {
            await this._HandleAndProcessInvoiceFromEvent(stripeEvent);
            return;
        }

        private async Task _HandleCustomerSubscriptionDeleted(Event stripeEvent)
        {
            await Task.FromResult<bool>(true);
            // @TODO Handle this
            return;
        }

        private async Task _HandleUnhandledEvents(Event? stripeEvent)
        {
            await Task.FromResult<bool>(true);
            var logInformation = "Received Stripe Event that we don't handle!";
            var logInformationData = new { Event = stripeEvent };
            this._logger.LogInformation(logInformation, logInformationData);
            return;
        }

        private async Task _HandleAndProcessInvoiceFromEvent(Event stripeEvent)
        {
            var invoice = stripeEvent.Data.Object as Invoice;

            if (invoice == null)
            {
                return;
            }

            var billingInvoice = await this._multitenancyDbContext.BillingInvoices
                .Where(bi => bi.ExternalInvoiceId == invoice.Id)
                .FirstOrDefaultAsync();

            var tenant = await this._multitenancyDbContext.Tenants
                .Where(tenant => tenant.Company.ExternalCustomerId == invoice.CustomerId)
                .FirstOrDefaultAsync();

            if (tenant == null)
            {
                return;
            }

            if (billingInvoice != null)
            {
                billingInvoice.TransactionDate =  invoice.Created;
                billingInvoice.PeriodStartDate = invoice.PeriodStart;
                billingInvoice.PeriodEndDate = invoice.PeriodEnd;
                billingInvoice.PaidDate = invoice.StatusTransitions.PaidAt;
                billingInvoice.AmountPaid = invoice.AmountPaid / 100;
                billingInvoice.AmountDue = invoice.AmountDue / 100;
                billingInvoice.Status = invoice.Paid ? BillingInvoiceStatus.Paid : BillingInvoiceStatus.Unpaid;
                billingInvoice.BillingReason = invoice.BillingReason;
                billingInvoice.InvoiceUrl = invoice.HostedInvoiceUrl;
                billingInvoice.InvoicePdfUrl = invoice.InvoicePdf;
                billingInvoice.ExternalInvoiceId = invoice.Id;
                billingInvoice.TenantId = tenant.Id;
                billingInvoice.UpdatedOn = DateTime.UtcNow;
                this._multitenancyDbContext.BillingInvoices.Update(billingInvoice);
            }
            else 
            {
                billingInvoice = new BillingInvoice
                {
                    TransactionDate =  invoice.Created,
                    PeriodStartDate = invoice.PeriodStart,
                    PeriodEndDate = invoice.PeriodEnd,
                    PaidDate = invoice.StatusTransitions.PaidAt,
                    AmountPaid = invoice.AmountPaid / 100,
                    AmountDue = invoice.AmountDue / 100,
                    Status = invoice.Paid ? BillingInvoiceStatus.Paid : BillingInvoiceStatus.Unpaid,
                    BillingReason = invoice.BillingReason,
                    InvoiceUrl = invoice.HostedInvoiceUrl,
                    InvoicePdfUrl = invoice.InvoicePdf,
                    ExternalInvoiceId = invoice.Id,
                    TenantId = tenant.Id
                };
                this._multitenancyDbContext.BillingInvoices.Add(billingInvoice);
            }

            tenant.IsActive = invoice.Paid;

            this._multitenancyDbContext.Tenants.Update(tenant);
            this._multitenancyDbContext.SaveChanges();
            return;
        }
    }
}
