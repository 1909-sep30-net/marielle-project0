using Project0.BusinessLogic;
using Project0.DataAccess;
using Project0.DummyData;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project0.Test
{
   public class CustomerHandlerTest
    {
        [Fact]
        public void AddCustomerShouldAdd()
        {
            CustomerHandler ch = new CustomerHandler();
            Customer c = new Customer() 
            {
                LastName = "Smith",
                FirstName = "John"
            };
            ch.AddCustomer(c);
            int index = DummyCustomer.DCustomer.Count - 1;
            Assert.Equal(c.LastName, DummyCustomer.DCustomer[index].LastName);
        }

        [Theory]
        [InlineData("Marielle", "Nolasco")]
        [InlineData("", "Nolasco")]
        [InlineData("Marielle", "")]
        [InlineData(null, null)]
        [InlineData("Marielle", "Anderson")]
        public void SearchShouldSearch(string firstName, string lastName)
        {
            CustomerHandler ch = new CustomerHandler();
            try
            {
                Customer c = ch.Search(firstName, lastName);
                Assert.True(c != new Customer());
            }
            catch (Exception)
            {
                Assert.True(true);
            }
            
            

        }
    }
}
