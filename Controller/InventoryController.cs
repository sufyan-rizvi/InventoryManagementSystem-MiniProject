using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Repository;

namespace InventoryManagementSystem.Controller
{
    internal class InventoryController
    {
        public static void GenerateReport()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            InventoryRepository.GetAll().ForEach(x =>
            {
                Console.WriteLine($"========== Invetory Location: {x.Location} ==========\n");
                Console.WriteLine("=================== Products ===================");
                x.Products.ForEach(Console.WriteLine);
                Console.WriteLine("=================== Suppliers ===================");
                x.Suppliers.ForEach(Console.WriteLine);
                Console.WriteLine("=================== Transactions ===================");
                x.Transactions.ForEach(Console.WriteLine);
            });
            Console.ResetColor();
        }
    }
}
