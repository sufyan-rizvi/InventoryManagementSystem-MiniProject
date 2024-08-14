using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;

namespace InventoryManagementSystem.Controller
{
    internal class MainMenuController
    {
        public static void MainMenu()
        {
            Console.WriteLine("Inventory Management App");
            while (true)
            {
                try
                {
                    DisplayMainMenu();
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\n");

                    if (!MainMenuChoice(choice))
                        break;
                }
                catch (Exception ex) { Console.WriteLine("\n" + ex.Message); }
            }
        }
        public static bool MainMenuChoice(int choice)
        {
            bool continueMenu = true;
            switch (choice)
            {
                case 1:

                    ProductMenuController.ProductMenu();
                    break;

                case 2:

                    SupplierMenuController.SupplierMenu();
                    break;

                case 3:

                    TransactionMenuController.TransactionMenu();
                    break;

                case 4:

                    InventoryController.GenerateReport();
                    break;

                case 5:

                    continueMenu = false;
                    break;

                default:
                    Console.WriteLine("Enter a valid option !");
                    break;
            }
            return continueMenu;
        }

        private static void DisplayMainMenu()
        {
            Console.Write($"\n" +
                $"Main Menu: \n\n" +
                $"1. Product Menu\n" +
                $"2. Supplier Menu\n" +
                $"3. Transaction Menu\n" +
                $"4. Generate Reports\n" +
                $"5. Exit Program\n" +
                $"Your Choice: ");
        }
    }
}
