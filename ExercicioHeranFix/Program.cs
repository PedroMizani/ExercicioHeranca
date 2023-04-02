using System;
using System.Collections.Generic;
using ExercicioHeranFix.Entities;
using System.Globalization;

namespace ExercicioHeranFix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("ENTER THE NUMBER OF PRODUCTS: ");
            int n = int.Parse(Console.ReadLine());

            List<Product> products = new List<Product>();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"PRODUCT #{i} DATA: ");
                Console.Write("Common, used or imported (c/u/i)? ");
                char ch = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture );

                if (ch == 'c')
                {
                    products.Add(new Product(name, price)); 
                }

                else if (ch == 'i')
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    products.Add(new ImportedProduct(name,price,customsFee));
                }

                else if (ch == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime manufactureDate = DateTime.Parse(Console.ReadLine());

                    products.Add(new UsedProduct(name, price, manufactureDate));
                }
               
            }

            Console.WriteLine();
            Console.WriteLine("Price Tags: ");

            foreach (Product prod in products)
            {
                Console.WriteLine(prod.PriceTag());
            }
        }
    }
}