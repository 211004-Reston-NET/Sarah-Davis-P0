using System;
using BusinessLogic;

namespace UserInterface
{
    public class AddCustomer : IMenu
    {
        private CustomerBL _customerbl;
        public AddCustomer(CustomerBL p_CustomerBL){
            _customerbl = p_CustomerBL;
        }
        public void Menu()
        {
            Console.WriteLine($"Name-{SingletonCustomer.customer.Name}");
            Console.WriteLine($"Address-{SingletonCustomer.customer.Address}");
            Console.WriteLine($"PhoneNumber-{SingletonCustomer.customer.PhoneNumber}");
            Console.WriteLine($"Email-{SingletonCustomer.customer.Email}");
            Console.WriteLine("Create New User");
            Console.WriteLine("[1]: Add Name");
            Console.WriteLine("[2]: Add Address");
            Console.WriteLine("[3]: Add Phone Number");
            Console.WriteLine("[4]: Add Email");
            Console.WriteLine("[5]: Add Password");
            Console.WriteLine("[6]: Finish Creating Account");
            Console.WriteLine("[0]: Back to Main Menu");

        }

        public MenuType UserChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    Console.WriteLine("Add Name");
                    SingletonCustomer.customer.Name = Console.ReadLine();
                    return MenuType.AddCustomer;
                 case "2":
                    Console.WriteLine("Add Address");
                    SingletonCustomer.customer.Address = Console.ReadLine();
                    return MenuType.AddCustomer;
                case "3":
                    Console.WriteLine("Add PhoneNumber");
                    SingletonCustomer.customer.PhoneNumber = Console.ReadLine();
                    return MenuType.AddCustomer;
                case "4":
                    if (String.IsNullOrEmpty(SingletonCustomer.customer.Email)){
                        Console.WriteLine("Please input email");}

                    Console.WriteLine("Add Email");
                    SingletonCustomer.customer.Email = Console.ReadLine();
                    return MenuType.AddCustomer;
               
                case "5":
                    Console.WriteLine("Add Password");
                    SingletonCustomer.customer.Password = Console.ReadLine();
                    return MenuType.AddCustomer;


                case "6":
                    if (String.IsNullOrEmpty(SingletonCustomer.customer.Password)){
                        Console.WriteLine("Please input a password");
                        return MenuType.AddCustomer;
                    } else {
                        Console.WriteLine("Account created!");
                    _customerbl.AddCustomer(SingletonCustomer.customer);
                     return MenuType.MainMenu;
                    }
                    
                case "7":
                    return MenuType.Exit;

                default:
                    Console.WriteLine(" Please select one of the options above. " +
                    "\n Please press Enter to continue.");
                    Console.WriteLine();
                    return MenuType.MainMenu;

            }
        }
    }

}
