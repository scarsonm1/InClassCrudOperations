using System;
using System.IO;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace InClassCrud_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
#if DEBUG
                    .AddJsonFile("appsettings.debug.json")
#else
                    .AddJsonFile("appsettings.release.json")
#endif
                    .Build();

            string ConnectionString = configBuilder.GetConnectionString("DefaultConnection");
            //Create
            Console.WriteLine("What category do you want to add?");

            string Category = Console.ReadLine();

            Console.WriteLine("What is the most you want to pay for a product today?");
            int maxPrice = int.Parse(Console.ReadLine());
            Repository repository = new Repository(ConnectionString);
            List<string> values = repository.GetProductsNameInPriceRange(maxPrice);

            foreach (string value in values)
            {
                Console.WriteLine(value);
            }

            Console.ReadLine();

            Console.WriteLine("What do you want the price of the Samsung Galaxy to be?");
            int newPrice = int.Parse(Console.ReadLine());

            Console.WriteLine("What product do you want to delete?");
            string productToDelete = Console.ReadLine();

        }
       

    }
}