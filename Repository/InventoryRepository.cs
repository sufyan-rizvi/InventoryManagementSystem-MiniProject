using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Repository
{
    internal class InventoryRepository
    {
        private static readonly InventoryContext _context;

        static InventoryRepository()
        {
            _context = InventoryContext.GetContext();
        }

        public static List<Inventory> GetAll()
        {
            
            return _context.Inventories.Include(x=>x.Products)
                .Include(x=>x.Suppliers)
                .Include(x=>x.Transactions)
                .ToList();
        }
    }
}
