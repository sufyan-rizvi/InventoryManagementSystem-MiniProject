using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;

namespace InventoryManagementSystem.Controller
{
    internal class TransactionMenuController
    {
        public static void TransactionMenu()
        {
            while (true)
            {
                try
                {
                    Console.ResetColor();
                    DisplayTransactionMenu();
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\n");
                    if (!TransactionMenuChoice(choice))
                        break;
                }
                catch (Exception ex) { Console.WriteLine("\n" + ex.Message); }
            }
        }
        private static bool TransactionMenuChoice(int choice)
        {
            bool continueMenu = true;
            switch (choice)
            {
                case 1:

                    AddStock();


                    break;

                case 2:

                    RemoveStock();

                    break;

                case 3:

                    ViewTransactionHistory();

                    break;

                case 4:
                    continueMenu = false;
                    break;
                default:
                    Console.WriteLine("Enter a valid option");
                    break;

            }
            return continueMenu;
        }

        private static void ViewTransactionHistory()
        {
            TransactionRepository.GetAll().ForEach(x =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(x);
                Console.ResetColor();
            }
            );
        }

        private static void RemoveStock()
        {
            Console.WriteLine("Available Products: ");
            ProductRepository.GetAll().ForEach(x => Console.WriteLine($"Product Id: {x.ProductID} Quantity: {x.Quantity}"));
            Console.WriteLine("Enter the Product ID");
            int id = Convert.ToInt32(Console.ReadLine());
            var product = ProductRepository.CheckIdUpdate(id);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(product);
            Console.ResetColor();
            Console.Write("Quantity to be removed: ");
            double quantity = Convert.ToDouble(Console.ReadLine());
            ProductRepository.CheckEnoughQuantityExists(product, quantity);

            product.Quantity -= quantity;
            Console.WriteLine("Quantity Removed !");
            ProductRepository.Update(product);

            TransactionRepository.AddEntry(
                new Transaction
                {
                    ProductID = product.ProductID,
                    Time = DateTime.Now,
                    Quantity = quantity,
                    Type = "Remove",
                    InventoryId = product.InventoryId

                }
                );
        }

        private static void AddStock()
        {
            Console.WriteLine("Available Products: ");
            ProductRepository.GetAll().ForEach(x => Console.WriteLine("Product Id: " + x.ProductID));
            Console.WriteLine("Enter the Product ID");
            int id = Convert.ToInt32(Console.ReadLine());

            var product = ProductRepository.CheckIdUpdate(id);

            Console.Write("Quantity to be added: ");
            double quantity = Convert.ToDouble(Console.ReadLine());
            product.Quantity += quantity;
            Console.WriteLine("Quantity added !");
            ProductRepository.Update(product);

            TransactionRepository.AddEntry(
                new Transaction
                {
                    ProductID = product.ProductID,
                    Time = DateTime.Now,
                    Quantity = quantity,
                    Type = "Add",
                    InventoryId = product.InventoryId
                }
                );

        }



        public static void DisplayTransactionMenu()
        {


            Console.Write($"\n" +
                $"Transaction Menu: \n\n" +
                $"1. Add Stock\n" +
                $"2. Remove Stock\n" +
                $"3. View Transaction History\n" +
                $"4. Exit to Main Menu\n" +
                $"Your Choice: ");
        }
    }
}
