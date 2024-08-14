using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace InventoryManagementSystem.Models
{
    internal class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public string Type { get; set; }
        public double Quantity { get; set; }
        public DateTime Time { get; set; }

        public Product Product { get; set; }//nav property

        [ForeignKey("ProductID")]
        public int ProductID { get; set; } //FK
        
        public Inventory Inventory { get; set; }

        [ForeignKey("InventoryId")]
        public int InventoryId { get; set; }


        public Transaction()
        {
            
        }

        public override string ToString()
        {
            return $"\n" +
                $"Transaction Id: {TransactionId}\n" +
                $"Product Id: {ProductID}\n" +
                $"Transaction Type: {Type}\n" +
                $"Quantity: {Quantity}\n" +
                $"Date: {Time}\n" +
                $"\n";
        }



    }
}
