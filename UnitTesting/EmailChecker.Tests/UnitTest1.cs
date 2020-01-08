using System;
using Xunit;

namespace EmailChecker.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("ich@provider.com")]
        public void DetectsCorrectAdress(string mailaddress)
        {
            bool result = EmailChecker.Program.IsEmailAddress(mailaddress);
            Assert.True(result, mailaddress + " nicht als Email-Adresse erkannt, obwohl korrekt.");
        }

        [Theory]
        [InlineData("@provider.com")]
        [InlineData("ich@provider")]
        [InlineData("ich@ich@provider.com")]
        [InlineData("ich@provider.c!om")]
        public void DetectsIncorrectAdress(string mailaddress)
        {
            bool result = EmailChecker.Program.IsEmailAddress(mailaddress);
            Assert.False(result, mailaddress + " als Email-Adresse erkannt, obwohl inkorrekt.");
        }
    }
}
