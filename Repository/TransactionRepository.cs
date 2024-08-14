using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace InventoryManagementSystem.Repository
{
    internal class TransactionRepository
    {
        private static readonly InventoryContext _context;

        static TransactionRepository()
        {
            _context = InventoryContext.GetContext();
        }
        public static List<Transaction> GetAll()
        {
            var listTransaction = _context.Transactions.ToList();
            if (listTransaction.Count > 0)
                return listTransaction;
            throw new DatabaseEmptyException("No transaction records in Database !");
        }

        public static void AddEntry(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        
    }

}
