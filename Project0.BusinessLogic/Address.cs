﻿using System;
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
        public string Street
        {
            get => street;

            set
            {
                if (Regex.Match(value, @"\d+\s[A-z0-9]+?(\s[A-z])*").Success) street = value;
                else
                {
                    throw new InvalidAddressException("Invalid Street");
                }
            }

        }
        public string City 
        {
            get
            {
                return city;
            }

            set 
            {
                if (Regex.Match(value, @"[A-z]+?(\s[A-z])*").Success) city = value;
                else { throw new InvalidAddressException("Invalid City"); }
            }
            
        }
        public States State 
        {
            get => state;
            set 
            {
                state = value;
            }
        }

        

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