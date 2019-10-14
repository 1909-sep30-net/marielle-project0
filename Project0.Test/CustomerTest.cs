using Project0.BusinessLogic;
using Xunit;

namespace Project0.Test
{
    public class CustomerTest
    {
        [Fact]
        public void CustomerShouldValidateStrings()
        {
            try
            {
                Customer c = new Customer()
                {
                    FirstName = "",
                    LastName = "",
                    CustAddress = null
                };
                Assert.True(false, "Failed");
            }
            catch (CustomerException ex)
            {
                Assert.True(true);
            }
        }
    }
}