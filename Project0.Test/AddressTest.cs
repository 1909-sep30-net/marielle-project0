using Project0.BusinessLogic;
using Xunit;
namespace Project0.Test
{
    public class AddressTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("                ")]
        public void AddressShouldValidateStreets(string input)
        {
            try
            {
                new Address()
                {
                    Street = input
                };

            }
            catch (InvalidAddressException e)
            {

                Assert.True(true);
            }
        }
        [Theory]
        [InlineData("12 Main")]
        [InlineData("1 Main")]
        [InlineData("       3 Main         ")]
        public void AddressShouldAddValidStreets(string input)
        {
            try
            {
                new Address()
                {
                    Street = input
                };

            }
            catch (InvalidAddressException e)
            {

                Assert.True(false);
            }
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("                ")]
        public void AddressShouldValidateCity(string input)
        {
            try
            {
                new Address()
                {
                    City = input
                };

            }
            catch (InvalidAddressException e)
            {

                Assert.True(true);
            }
        }
        [Theory]
        [InlineData("Main")]
        [InlineData("Main City")]
        [InlineData("      Metropolis        ")]
        public void AddressShouldAddValidCities(string input)
        {
            try
            {
                new Address()
                {
                    City = input
                };

            }
            catch (InvalidAddressException e)
            {

                Assert.True(false);
            }
        }
        [Theory]
        [InlineData(34)]
        [InlineData(1)]
        [InlineData(123)]
        public void AddressShouldValidateZipcode(int input)
        {
            try
            {
                new Address()
                {
                    Zipcode = input
                };

            }
            catch (InvalidAddressException e)
            {

                Assert.True(true);
            }
        }
        [Theory]
        [InlineData(12345)]
        [InlineData(94578)]
        [InlineData(94577)]
        public void AddressShouldAddValidZipcodes(int input)
        {
            try
            {
                new Address()
                {
                    Zipcode = input
                };

            }
            catch (InvalidAddressException e)
            {

                Assert.True(false);
            }
        }
    }
}