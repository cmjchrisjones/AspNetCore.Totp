﻿using Xunit;

namespace AspNetCore.Totp.Tests
{
    public class TotpValidatorTests
    {
        private readonly TotpValidator totpValidator;
        private readonly TotpGenerator totpGenerator;
        
        public TotpValidatorTests()
        {
            this.totpValidator = new TotpValidator();
            this.totpGenerator = new TotpGenerator();
        }

        [Fact]
        public void Validate_TotpGeneratedByGoogleAuthenticatorIsNotValid()
        {
            var validated = this.totpValidator.Validate("7FF3F52B-2BE1-41DF-80DE-04D32171F8A3", 284621);
            Assert.False(validated);
        }

        [Fact]
        public void Validate_TotpGeneratedByGoogleAuthenticatorIsValid()
        {
            var totp = this.totpGenerator.Generate("7FF3F52B-2BE1-41DF-80DE-04D32171F8A3");
            var validated = this.totpValidator.Validate("7FF3F52B-2BE1-41DF-80DE-04D32171F8A3", totp, 0);
            Assert.True(validated);
        }
    }
}
