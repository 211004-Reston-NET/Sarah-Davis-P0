using System;
using Models;

namespace UserInterface
{
    public class SingletonCustomer
    {
        public static Customer customer = new Customer();
        public static Order order = new Order();
        public static int StoreId{ get; set;}
    }
}