using System.Text.RegularExpressions;

namespace Project0.BusinessLogic
{
    /// <summary>
    /// Customer format of the program
    /// UI interacts with this format of customer
    /// </summary>
    public class Customer
    {
        private string firstName;
        private string lastName;
        private Address custAddress;
        private int custID;

        /// <summary>
        /// First Name property of Customer class (Includes format validation)
        /// </summary>
        public string FirstName
        {
            get => firstName;
            set
            {
                try
                {
                    validate(value);
                    firstName = value;
                }
                catch (CustomerException)
                {
                    throw new CustomerException("Invalid First Name");
                }
            }
        }

        /// <summary>
        /// Last Name Property of Customer Class (Includes format validation)
        /// </summary>
        public string LastName
        {
            get => lastName;
            set
            {
                try
                {
                    validate(value);
                    lastName = value;
                }
                catch (CustomerException)
                {
                    throw new CustomerException("Invalid Last Name");
                }
            }
        }

        /// <summary>
        /// Address Property of Customer Class (Input Validation Done in Address Class)
        /// </summary>
        public Address CustAddress { get; set; }

        public int CustID { get; set; }

        /// <summary>
        /// Method that validates Customer name inputs in class
        /// </summary>
        /// <param name="s"></param>
        private void validate(string s)
        {
            if (!Regex.Match(s, @"\s*[A-z]+\s*?([A-z]\s*)").Success) throw new CustomerException("Empty Input");
        }
    }
}