using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace DataAccessLogic{

    public class RepositoryCloud: IRepository
{
        private RRDatabaseContext _context;
        public RepositoryCloud(RRDatabaseContext p_context) 
        {
            _context = p_context;
        }
        public Customer AddCustomer(Customer p_customer)
        {
            _context.Customers.Add(p_customer);

            
            _context.SaveChanges();
            return p_customer;
        }

        
        public List<LineItem>  GetAllLineItemByStore(int p_StoreId)
        {
            // return _context.LineItems.Where(p => p.StorefrontId == p_StoreId).ToList(); 
            return _context.LineItems
            .Where(item => item.Storefront.StoreFrontId == p_StoreId)
            .Select(item => 
                new LineItem()
                {
                    Product = new Product(){
                        Name = item.Product.Name,
                        Price = item.Product.Price,
                        Description = item.Product.Description,
                        Category = item.Product.Category,
                        ProductId = item.Product.ProductId
                    },
                    Quantity = item.Quantity,
                    LineItemId = item.LineItemId,
                    StorefrontId = item.StorefrontId
                }
            ).ToList();

        }

        public List<Product> GetAllProducts(Product p_product)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByEmail(String p_email)
        {
            return _context.Customers.Where(Customer => p_email == Customer.Email).Single();
           
        }
        public List<StoreFront> GetAllStorefront()
        {
            //Method Syntax
            return _context.Storefronts.ToList();
            
        }

        public void PlaceOrder(Customer p_customer, Order p_order)
        {
            Customer found = _context.Customers.FirstOrDefault(c => c.Id == p_customer.Id);
            found.ListOfOrders.Add(p_order);
            _context.SaveChanges();
        }
        
    }
}

