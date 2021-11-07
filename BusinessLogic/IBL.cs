using System.Collections.Generic;
using Models;

namespace BusinessLogic
{
    public interface IBL
    {
       List<LineItem> GetAllLineItemByStore(int p_StoreId);

        /// <summary>
        /// Gets all storefronts from DB and returns as storefronts
        /// </summary>
        /// <returns>returns a list of storefront</returns>
        List<StoreFront> GetStoreFronts();  
        /// <summary>
        /// This will select customer and add an order
        /// </summary>
        /// <param name="p_customer">This is how you find the customer to add the orders to</param>
        /// <param name="p_order">This is the order that will be added</param>
        void PlaceOrder(Customer p_customer, Order p_order); 
    }
}
