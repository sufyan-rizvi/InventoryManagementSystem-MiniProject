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
    internal class SupplierMenuController
    {

        public static void SupplierMenu()
        {
            while (true)
            {
                try
                {
                    Console.ResetColor();
                    DisplaySupplierMenu();
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\n");
                    if (!SupplierMenuChoice(choice))
                        break;
                }
                catch (Exception ex) { Console.WriteLine("\n" + ex.Message); }

            }
        }

        private static bool SupplierMenuChoice(int choice)
        {
            bool continueMenu = true;
            switch (choice)
            {
                case 1:

                    AddSupplier();
                    break;

                case 2:

                    UpdateSupplier();
                    break;

                case 3:

                    DeleteSupplier();
                    break;

                case 4:

                    ViewSupplierDetail();
                    break;

                case 5:

                    ViewAllSuppliers();
                    break;

                case 6:

                    continueMenu = false;
                    break;

                default:
                    Console.WriteLine("Enter a valid option");
                    break;

            }
            return continueMenu;
        }

        private static void ViewAllSuppliers()
        {
            SupplierRepository.GetAll().ForEach(x =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(x);
                Console.ResetColor();
            });
        }
        private static void ViewSupplierDetail()
        {
            Console.Write("Enter Supplier Id you want to view: ");
            int supplierId = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(SupplierRepository.GetSupplierDetails(supplierId));
            Console.ResetColor();



        }

        private static void DeleteSupplier()
        {
            Console.Write("Enter Supplier Id you want to DELETE: ");
            int supplierId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(SupplierRepository.Delete(supplierId));
            Console.WriteLine("Supplier Removed !");

        }

        private static void UpdateSupplier()
        {
            Console.Write("Enter Supplier Name you want to Update: ");
            string supplierName = Console.ReadLine().ToLower();
            var supplier = SupplierRepository.GetByName(supplierName);

            if (supplier != null)
            {
                Console.Write("Enter new Name for Supplier: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter new Contact Detail of Supplier: ");
                string contact = Console.ReadLine();

                Console.WriteLine("Enter inventory Location Id: 1: Mumbai, 2: Navi-Mumbai");
                int inventoryId = Convert.ToInt32(Console.ReadLine());

                SupplierRepository.Update(
                    new Supplier
                    {
                        SupplierID = supplier.SupplierID,
                        SupplierName = name,
                        SupplierContactInfo = contact,
                        InventoryId = inventoryId
                    });
                Console.WriteLine("Supplier Updated !");
            }
            else
                throw new IdNotFoundException("No supplier with that Name !");
        }

        private static void AddSupplier()
        {
            Console.Write("Enter new Name for Supplier: ");
            string name = Console.ReadLine();
            Console.Write("Enter new Contact Detail of Supplier: ");
            string contact = Console.ReadLine();
            Console.WriteLine("Enter inventory Location Id: 1: Mumbai, 2: Navi-Mumbai");
            int inventoryId = Convert.ToInt32(Console.ReadLine());
            SupplierRepository.Update(
                new Supplier
                {
                    SupplierName = name,
                    SupplierContactInfo = contact,
                    InventoryId = inventoryId
                });
            Console.WriteLine("Supplier Added !");

        }

        private static void DisplaySupplierMenu()
        {
            Console.Write($"\n" +
                $"Supplier Menu: \n\n" +
                $"1. Add Supplier\n" +
                $"2. Update Supplier\n" +
                $"3. Delete Supplier\n" +
                $"4. View Supplier's Details\n" +
                $"5. View All Suppliers\n" +
                $"6. Exit to Main Menu\n" +
                $"Your Choice: ");
        }
    }
}
