using Xyz.Core.Models.Multitenancy.Payments;

namespace Xyz.Core.Interfaces.Multitenancy
{
    public interface IPaymentProcessorService
    {
        public Task<CreatePaymentMethodResponse> CreatePaymentMethod(CreatePaymentMethodRequest request);
        public Task<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest request);
        public Task<CreateSubscriptionResponse> CreateSubscription(CreateSubscriptionRequest request);
        public Task<object> CancelSubscription(object subscription);
        public Task<object> UpdateSubscription(object subscription);
        public Task<object> ListSubscriptions();
        public Task ProcessWebhook<T>(T webhookData);
    }
}