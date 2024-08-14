using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InventoryManagementSystem.Models
{
    internal class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double Quantity { get; set; }
        public double Price {  get; set; }

        public Inventory Inventory { get; set; }

        [ForeignKey("InventoryId")]
        public int InventoryId { get; set; }


        public Product()
        {
            
        }

        public override string ToString()
        {
            return $"\n" +
                $"Product Id: {ProductID}\n" +
                $"Product Name: {ProductName}\n" +
                $"Product Description: {ProductDescription}\n" +
                $"Quantity: {Quantity}\n" +
                $"Price: {Price}\n" +
                $"\n";
        }

    }

}
