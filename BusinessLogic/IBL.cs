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
 
    }
}
