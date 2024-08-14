using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InventoryManagementSystem.Models
{
    internal class Supplier
    {
        [Key]
        public int SupplierID {  get; set; }
        public string SupplierName {  get; set; }
        public string SupplierContactInfo {  get; set; }
        public Inventory Inventory { get; set; }
        [ForeignKey("InventoryId")]
        public int InventoryId { get; set; }

        public Supplier()
        {
            
        }
        public override string ToString()
        {
            return $"\n" +
                $"Supplier Id: {SupplierID}\n" +
                $"Supplier Name: {SupplierName}\n" +
                $"Supplier Contact: {SupplierContactInfo}\n" +
                $"\n";
        }
    }
}
