using Models;

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
    }
}