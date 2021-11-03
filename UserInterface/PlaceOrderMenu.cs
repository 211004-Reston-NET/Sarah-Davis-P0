using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class PlaceOrderMenu: IMenu
    {
        private IBL _IBL;
        public PlaceOrderMenu(IBL p_prodBL) => this._IBL = p_prodBL;
        public void Menu()
        {
            Console.WriteLine("List of Products");
            List<LineItem> lineItemsList = _IBL.GetAllLineItemByStore(SingletonCustomer.StoreId);
            Console.WriteLine("Shopping Cart");
            Console.WriteLine("=============");
            foreach (LineItem item in SingletonCustomer.order.LineItem)
            {
                Console.WriteLine(item);
                Console.WriteLine("=============");
            }
            Console.WriteLine("[1] - Add item");
            Console.WriteLine("[2] - Checkout");
            Console.WriteLine("[0] - Back to Products");

        }
        public MenuType UserChoice()
        
        {
            
            List<LineItem> lineItemsList = _IBL.GetAllLineItemByStore(SingletonCustomer.StoreId);
            string userChoice = Console.ReadLine();
            switch (userChoice)
            { 
                
                case "1": 
                Console.WriteLine("Please input item ID");
                int _inputInt = int.Parse(Console.ReadLine().Trim());
                
                    foreach(LineItem prod in lineItemsList)
                    {
                        
                            if (_inputInt == prod.Product.ProductId)
                            {
                                SingletonCustomer.order.LineItem.Add(prod);
                            }   
                    
                    }
                
                   return MenuType.PlaceOrderMenu; 
                case "0":
                    return MenuType.ShowProducts;
                case "2": 
                    return MenuType.Purchases;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.PlaceOrderMenu;
                
            }
                
        }
        
    }
}


