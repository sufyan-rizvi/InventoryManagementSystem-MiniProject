using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;

namespace InventoryManagementSystem.Controller
{
    internal class ProductMenuController
    {
        public static void ProductMenu()
        {
            while (true)
            {
                try
                {
                    Console.ResetColor();
                    DisplayProductMenu();
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\n");
                    if (!ProductMenuChoice(choice))
                        break;
                }
                catch (Exception ex) { Console.WriteLine("\n" + ex.Message); }
            }
        }
        private static bool ProductMenuChoice(int choice)
        {
            bool continueMenu = true;
            switch (choice)
            {
                case 1:

                    AddProduct();
                    break;
                case 2:

                    UpdateProduct();
                    break;
                case 3:

                    DeleteProduct();
                    break;

                case 4:

                    ViewProductDetail();
                    break;

                case 5:

                    ViewAllProducts();
                    break;

                case 6:
                    continueMenu = false;
                    break;

                default:
                    Console.WriteLine("Enter a valid option !");
                    break;

            }
            return continueMenu;

        }

        private static void ViewAllProducts()
        {
            ProductRepository.GetAll().ForEach(x =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(x);
                Console.ResetColor();
            });
        }

        private static void ViewProductDetail()
        {
            Console.Write("Enter Product Id you want to view: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine(ProductRepository.GetProductDetails(productId));
            Console.ResetColor();
        }

        private static void DeleteProduct()
        {
            Console.Write("Enter Product Id you want to DELETE: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(ProductRepository.Delete(productId));
            Console.WriteLine("Product Removed !");
        }

        private static void UpdateProduct()
        {
            Console.Write("Enter Product Id you want to Update: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            var product = ProductRepository.CheckIdUpdate(productId);


            Console.Write("Enter new Name for product: ");
            string name = Console.ReadLine()!;
            ProductRepository.CheckNameAdd(name);

            Console.Write("Enter new description for product: ");
            string description = Console.ReadLine()!;
            Console.Write("Enter new Price for Product: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter inventory Location Id: 1: Mumbai, 2: Navi-Mumbai");
            int inventoryId = Convert.ToInt32(Console.ReadLine());

            ProductRepository.Update(
                new Product
                {
                    ProductID = product.ProductID,
                    ProductName = name,
                    ProductDescription = description,
                    Price = price,
                    InventoryId = inventoryId
                });
            Console.WriteLine("Product Updated !");

        }

        private static void AddProduct()
        {
            Console.Write("Enter Name for Product: ");
            string name = Console.ReadLine()!;
            ProductRepository.CheckNameAdd(name);
            Console.Write("Enter description for Product: ");
            string description = Console.ReadLine()!;
            Console.Write("Enter Price for the product: ");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter inventory Location Id: 1: Mumbai, 2: Navi-Mumbai");
            int inventoryId = Convert.ToInt32(Console.ReadLine());

            ProductRepository.Add(
                new Product
                {
                    ProductName = name,
                    ProductDescription = description,
                    Quantity = 0,
                    Price = price,
                    InventoryId = inventoryId                    
                });
            Console.WriteLine("Product Added !");
        }

        public static void DisplayProductMenu()
        {
            Console.Write($"\n" +
                $"Product Menu: \n\n" +
                $"1. Add Product\n" +
                $"2. Update Product\n" +
                $"3. Delete Product\n" +
                $"4. View Product Details\n" +
                $"5. View All Products\n" +
                $"6. Exit to Main Menu\n" +
                $"Your Choice: ");
        }
    }
}
