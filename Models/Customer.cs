using System;
using System.Text.RegularExpressions;

namespace Models
{
    public class Customer
    {

        private string _name;
        private string _address;
        private string _email;
        private string _phoneNumber;
        private string _listoforders;

        public string Name
        {
            get { return _name; }
            set
            {
                if (!Regex.IsMatch(value, @"^[a-zA-Z]+(\s[a-zA-Z]+)?$"))
                {
                    throw new Exception("Name can only hold letters.");
                }
                _name = value;
            }

        }
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
            }

        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
            }
        }
         
    }

}