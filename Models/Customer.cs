using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Models
{
    public class Customer
    {
        private int _id;
        private string _name;
        private string _address;
        private string _email;
        private string _phoneNumber;
        private List<Order> _listoforders;
        private string _password;

        

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
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
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
         
         public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
         public List <Order> ListOfOrders
        {
            get { return _listoforders; }
            set
            {
                _listoforders = value;
            }
        }
       
    }
}