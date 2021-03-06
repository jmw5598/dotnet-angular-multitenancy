using System.ComponentModel.DataAnnotations;

using Xyz.Core.Entities.Multitenancy;
using Xyz.Core.Entities.Identity;
using Xyz.Core.Models;
using Xyz.Core.Models.Multitenancy;

namespace Xyz.Api.Models
{
    public class RegistrationDto
    {
        [Required]
        public RegistrationUserDto User { get; set; } = null!;

        [Required]
        public RegistrationProfileDto Profile { get; set; } = null!;

        [Required]
        public RegistrationCompanyDto Company { get; set; } = null!;

        [Required]
        public RegistrationPlanDto Plan { get; set; } = null!;

        public RegistrationPaymentDetailsDto? PaymentDetails { get; set; } = null!;

        public Registration ToRegistration()
        {
            return new Registration
            {
                User = new ApplicationUser
                {
                    UserName = this.User.UserName,
                    NormalizedUserName = this.User.UserName.ToUpper(),
                    Email = this.User.UserName,
                    NormalizedEmail = this.User.UserName.ToUpper(),
                    EmailConfirmed = true
                },
                Profile = new Profile
                {
                    FirstName = this.Profile.FirstName,
                    LastName = this.Profile.LastName
                },
                Company = new Company
                {
                    Name = this.Company.Name
                },
                Plan = new Plan
                {
                    Id = new Guid(this.Plan.Id)
                },
                PaymentDetails = this.PaymentDetails != null 
                    ? new PaymentDetails {
                        FirstName = this.PaymentDetails.FirstName,
                        LastName = this.PaymentDetails.LastName,
                        Address = this.PaymentDetails.Address,
                        City = this.PaymentDetails.City,
                        State = this.PaymentDetails.State,
                        Zip = this.PaymentDetails.Zip,
                        PaymentProcessor = PaymentProcessor.STRIPE,
                        CardDetails = new CardDetails
                        {
                            IsValid = this.PaymentDetails.CardDetails.IsValid,
                            Brand = this.PaymentDetails.CardDetails.Brand,
                            Token = this.PaymentDetails.CardDetails.Token
                        }
                    } 
                    : null,
                Subdomain = this.Company.Subdomain,
                RawPassword = this.User.Password
            };
        }
    }
}
