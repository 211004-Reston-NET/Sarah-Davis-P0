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
    }
}