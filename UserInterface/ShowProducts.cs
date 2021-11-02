using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class ShowProducts : IMenu
    {
        private IBL _IBL;
        public ShowProducts(IBL p_prodBL)
        {
            this._IBL = p_prodBL;
        }
        public void Menu()
        {
            Console.WriteLine("List of Products");
            List<LineItem> lineItemsList = _IBL.GetAllLineItemByStore(SingletonCustomer.StoreId);

            foreach (LineItem item in lineItemsList)
            {
                Console.WriteLine("====================");
                Console.WriteLine(item);
                Console.WriteLine("====================");
            }
            Console.WriteLine("[1] - Place order");
            Console.WriteLine("[0] - Go Back");
        }


        public MenuType UserChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            { 
                case "1": 
                return MenuType.PlaceOrderMenu;
                case "0":
                    return MenuType.ViewStorefronts;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ShowProducts;
            }
        }
    }
}


