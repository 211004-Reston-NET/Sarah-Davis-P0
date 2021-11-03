using System;
using BusinessLogic;


namespace UserInterface
{
    internal class Login : IMenu
    {
        private CustomerBL _customerbl;

        public Login(CustomerBL p_LoginBL)
        {
            _customerbl = p_LoginBL;
        }
        public void Menu()
        {
            Console.WriteLine($"Email-{SingletonCustomer.customer.Email}");
            Console.WriteLine($"Password-{SingletonCustomer.customer.Password}");
            Console.WriteLine("[1]: Input Email");
            Console.WriteLine("[2]: Input Password");
            Console.WriteLine("[3]: Finish Login");
            Console.WriteLine("====================");
            Console.WriteLine("[0]: Back to Main Menu");
            

        }
        public MenuType UserChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                
                case "1":
                    if (String.IsNullOrEmpty(SingletonCustomer.customer.Email))
                    {
                        Console.WriteLine("Please input email");
                    }

                    // Console.WriteLine("Add Email");
                    SingletonCustomer.customer.Email = Console.ReadLine();
                    return MenuType.LogIn;
               
                case "2":
                    Console.WriteLine("Add Password");
                    SingletonCustomer.customer.Password = Console.ReadLine();
                    return MenuType.LogIn;


                case "3":
                    if (String.IsNullOrEmpty(SingletonCustomer.customer.Password)){
                        Console.WriteLine("Add Password");
                        SingletonCustomer.customer.Password = Console.ReadLine();
                        return MenuType.LogIn;
                    } else {
                        if (_customerbl.ValidateCustomerLogin(SingletonCustomer.customer.Email,SingletonCustomer.customer.Password)){
                            Console.WriteLine("Login Successful!");
                        return MenuType.ViewStorefronts;
                        }
                        else {
                            Console.WriteLine("Your password was invalid");
                            return MenuType.MainMenu;
                        }
                        
                    }
                
                case "0":
                    return MenuType.MainMenu;

                default:
                    Console.WriteLine("");
                    Console.WriteLine();
                    return MenuType.MainMenu;
            }
        }
    }
}

            
             