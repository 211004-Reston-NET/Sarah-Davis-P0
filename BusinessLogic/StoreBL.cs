using System.Collections.Generic;
using DataAccessLogic;
using Models;

namespace BusinessLogic
{
    public class StoreBL : IBL
    {
        private IRepository repositoryCloud;

        public StoreBL(IRepository p_repositoryCloud)
        {
            this.repositoryCloud = p_repositoryCloud;
        }

        public List<LineItem> GetAllLineItemByStore(int p_StoreId)
        {
            return repositoryCloud.GetAllLineItemByStore(p_StoreId) ;
        }

        public List<StoreFront> GetStoreFronts()
        {
            return repositoryCloud.GetAllStorefront();
        }

        public void PlaceOrder(Customer p_customer, Order p_order)
        {
           repositoryCloud.PlaceOrder(p_customer, p_order);
        }
    }
}