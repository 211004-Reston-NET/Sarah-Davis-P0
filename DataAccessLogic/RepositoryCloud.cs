using System;
using Entity = DataAccessLogic.Entities;

namespace DataAccessLogic{

    public class RepositoryCloud: IRepository
{
        private Entity.RRDatabaseContext _context;
        public RepositoryCloud(Entity.RRDatabaseContext p_context) 
        {
            _context = p_context;
        }
        public Models.Customer AddCustomer(Models.Customer p_customer)
        {
            _context.Customers.Add
            (
                new Entity.Customer()
                {
                    CustomerName = p_customer.Name,
                    CustomerEmail = p_customer.Email,
                    CustomerAddress = p_customer.Address,
                    CustomerPhoneNumber = p_customer.PhoneNumber


                }
            );

            //This method will save the changes made to the database
            _context.SaveChanges();

            return p_customer;
        }
}
}

