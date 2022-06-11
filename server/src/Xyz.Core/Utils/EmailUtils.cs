namespace Xyz.Core.Util
{
    public static class EmailUtils
    {
        public static string GenerateNewTenantRegistrationVerificationEmail()
        {
            // @TODO generate tenant registration verification link
            var verificationLink = "";
            return @$"
                <h1>New Company Verification</h1>
                <p>Use the link below to verify your new company account, link is valid for 24 hours.</p>
                <a href=""""{verificationLink}"""">{verificationLink}</a>
            ";
        }

        public static string GenerateNewUserAccountRegistrationVerificationEmail()
        {
            // @TODO generate user account registration verification link
            var verificationLink = "";
            return @$"
                <h1>User Account Verification</h1>
                <p>Use the link below to verify your new user account, link is valid for 24 hours.</p>
                <a href=""""{verificationLink}"""">{verificationLink}</a>
            ";
        }
        
        public static string GeneratePasswordResetRequestEmail()
        {
            // @TODO generate password reqset link for email
            var passwordResetLink = "";
            return @$"
                <h1>Password Reset Request</h1>
                <p>Use the link below to reset your password, link is valid for 24 hours.</p>
                <a href=""""{passwordResetLink}"""">{passwordResetLink}</a>
            ";
        }
    }
}
