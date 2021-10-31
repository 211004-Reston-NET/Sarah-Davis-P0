using System;
using Entity = DataAccessLogic.Entities;
using System.Collections.Generic;
using System.Linq;

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
                    CustomerPhoneNumber = p_customer.PhoneNumber,
                    CustomerPassword = p_customer.Password


                }
            );

            
            _context.SaveChanges();

            return p_customer;
        }

        
        public List<Models.Product> GetAllProducts(Models.Product p_product)
        {
            return _context.Products
                
                .Select(product => new Models.Product(){ 
                  Id = product.ProductId,
                  Name = product.ProductName,
                  Price = product.ProductPrice,
                  Description = product.ProductCategory,
                })
                .ToList(); 
        }
        public Models.Customer GetCustomerByEmail(String p_email)
        {
            Entity.Customer custToFind = _context.Customers.Where(Customer => p_email == Customer.CustomerEmail).Single();
            
            return new Models.Customer(){
                Id = custToFind.CustomerId,
                Name = custToFind.CustomerName,
                Email = custToFind.CustomerEmail,
                Address = custToFind.CustomerAddress,
                PhoneNumber = custToFind.CustomerPhoneNumber,
                Password= custToFind.CustomerPassword,
                ListOfOrders = custToFind.OrderPages.Select(order =>new Models.Order(){
                    Id = order.OrderId
                }).ToList()
          
            };
        }
}
}

