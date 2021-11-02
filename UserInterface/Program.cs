using System;
using System.IO;
using BusinessLogic;
using DataAccessLogic;
using DataAccessLogic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UserInterface
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool repeat = true;

            IMenu page = new MainMenu();
            while (repeat)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsetting.json")
                    .Build();
                DbContextOptions<RRDatabaseContext> options = new DbContextOptionsBuilder<RRDatabaseContext>()
                    .UseSqlServer(configuration.GetConnectionString("RRDatabase"))
                    .Options;


                Console.Clear();
                page.Menu();
                MenuType userInput = page.UserChoice();
                switch (userInput)
                {
                    case MenuType.MainMenu:
                        page = new MainMenu();
                        break;

                    case MenuType.LogIn:
                        page = new Login(new CustomerBL(new RepositoryCloud(new RRDatabaseContext(options))));
                        break;

                    case MenuType.AddCustomer:
                        page = new AddCustomer(new CustomerBL(new RepositoryCloud(new RRDatabaseContext(options))));
                        break;
                    case MenuType.ViewStorefronts:
                        page = new ViewStorefronts (new StoreBL(new RepositoryCloud(new RRDatabaseContext(options))));
                        break;
                    case MenuType.ShowProducts:
                        page = new ShowProducts(new StoreBL(new RepositoryCloud(new RRDatabaseContext(options))));
                        break;
                    case MenuType.PlaceOrderMenu:
                        page = new PlaceOrderMenu(new StoreBL(new RepositoryCloud(new RRDatabaseContext(options))));
                        break;
                    case MenuType.Exit:
                        Console.WriteLine("We're sorry to see you go!");
                        Console.WriteLine("Press Enter to Exit");
                        Console.ReadLine();
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("See you soon");
                        repeat = false;
                        break;
                }
            }

        }
    }

}
