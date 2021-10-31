using System.Collections.Generic;
using Models;
using System;

namespace DataAccessLogic
{
    public interface IRepository 
    {
        /// <summary>
        /// Adding Customer to database
        /// </summary>
        /// <param name="p_customer">This will be the customer added to database</param>
        /// <returns>This returns customer added</returns>
        Customer AddCustomer(Customer p_customer);

        /// <summary>
        /// This will return a list of restaurants stored in the database
        /// </summary>
        /// <returns>It will return a list of restaurants</returns>
        List<Product> GetAllProducts(Product p_product);

         Models.Customer GetCustomerByEmail(String p_email);
    }

    
}