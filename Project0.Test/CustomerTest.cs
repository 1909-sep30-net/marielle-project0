using System;
using Xunit;
using Project0.BusinessLogic;
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
                    UserName = "",
                    CustAddress = null
                };
                Assert.True(false, "Failed");
            }
            catch (CustomerException ex)
            {

                throw ex;
            }

            
        }
    }
}
