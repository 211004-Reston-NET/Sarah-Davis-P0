using System;
using DataAccessLogic;
using Models;

namespace BusinessLogic
{
    public class CustomerBL
    {
        private IRepository _repo;

        public CustomerBL(IRepository p_repo)
        {
            _repo = p_repo;

        }
        public Customer AddCustomer(Customer p_customer)
        {
            return _repo.AddCustomer(p_customer);
        }

        public Boolean ValidateCustomerLogin(String email, String password)
        {
            Customer customer = _repo.GetCustomerByEmail(email);
            Console.WriteLine(customer);
            if (customer.Password.Equals(password))
            {
                return true;
            }
            else { return false; }

        }
        public Customer CustomerLogin(String email, String password)
        {
            Customer customer = _repo.GetCustomerByEmail(email);
            Console.WriteLine(customer);
            if (customer.Password.Equals(password))
            {
                return customer;
            }
            return null;
        }
    }
}