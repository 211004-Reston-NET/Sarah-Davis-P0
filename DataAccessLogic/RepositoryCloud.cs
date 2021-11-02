using System;
using Entity = DataAccessLogic.Entities;
using System.Collections.Generic;
using System.Linq;
using Models;

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

        
        public List<Models.LineItem>  GetAllLineItemByStore(int p_StoreId)
        {

            return _context.LineItems
                .Where(p => p.StorefrontId == p_StoreId)
                .Select(item => new Models.LineItem(){ 
                  LineItemId = item.LineItemId,
                  StorefrontId = item.StorefrontId,
                  Quantity = item.LineItemQuantity,
                  Product = new Models.Product(){
                      ProductId = item.Product.ProductId,
                      Price = item.Product.ProductPrice,
                      Name = item.Product.ProductName,
                      Description = item.Product.ProductDescription,
                      Category = item.Product.ProductCategory

                  }
                }
            ).ToList(); 
        }

        public List<Product> GetAllProducts(Product p_product)
        {
            throw new NotImplementedException();
        }

        public Models.Customer GetCustomerByEmail(String p_email)
        {
            Entity.Customer custToFind = _context.Customers.Where(Customer => p_email == Customer.CustomerEmail).Single();
            return new Models.Customer()
            {
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
        public List<Models.StoreFront> GetAllStorefront()
        {
            //Method Syntax
            return _context.Storefronts.Select(Store => 
                new Models.StoreFront()
                {
                    Name = Store.StorefrontName,
                    Address = Store.StorefrontAddress,
                    StoreFrontId = Store.StorefrontId,
                   
                }
            ).ToList();
        }
    }
}

