using System.Text.RegularExpressions;

namespace Project0.BusinessLogic
{
    /// <summary>
    /// Address format of program
    /// </summary>
    public class Address
    {
        private string street, city;
        private States state;
        private int zipcode;

        ///<summary>
        ///Street Property of Address class(Includes format validation)
        /// </summary>
        public string Street
        {
            get => street;

            set
            {
                if (value == null) throw new InvalidAddressException("Invalid Street");
                else if (Regex.Match(value, @"\s*\d+\s[A-z0-9]+\s*?(\s[A-z])*").Success) street = value;
                else
                {
                    throw new InvalidAddressException("Invalid Street");
                }
            }
        }

        /// <summary>
        /// City Property of Address class(Includes format validation)
        /// </summary>
        public string City
        {
            get
            {
                return city;
            }

            set
            {
                if (value == null) throw new InvalidAddressException("Invalid City");
                else if (Regex.Match(value, @"\s*[A-z]+\s*?(\s[A-z])*").Success) city = value;
                else { throw new InvalidAddressException("Invalid City"); }
            }
        }

        /// <summary>
        /// State property of Address class (Enum)
        /// </summary>
        public States State
        {
            get => state;
            set
            {
                state = value;
            }
        }

        /// <summary>
        /// Zipcode property of Address class(Includes format validation)
        /// </summary>
        public int Zipcode
        {
            get => zipcode;
            set
            {
                if (Regex.Match(value.ToString(), @"\d{5}").Success) zipcode = value;
                else { throw new InvalidAddressException("Invalid Zipcode"); }
            }
        }
    }
}