using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class ViewStorefronts : IMenu
    {
        private StoreBL _storeBl;
        public ViewStorefronts(StoreBL p_storeBl){
            _storeBl = p_storeBl;
        }
        public void Menu()
            
        {
           
            int Counter = 0;
            List<StoreFront> StorefrontList = _storeBl.GetStoreFronts();
            foreach (StoreFront Store in StorefrontList)
            {
               Counter++;
               Console.WriteLine(Counter);
               Console.WriteLine(Store.Name) ;
               Console.WriteLine(Store.Address);
               Console.WriteLine("============");
            }
             Console.WriteLine("Which location will you be shopping? Input 1 or 2");
        }

        public MenuType UserChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1": 
                    SingletonCustomer.StoreId = 417;
                    return MenuType.ShowProducts; 
                case "2": SingletonCustomer.StoreId = 419; 
                    return MenuType.ShowProducts;
                    
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ShowProducts;
            }
        }
    }
}