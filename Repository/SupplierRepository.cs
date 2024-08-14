using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Repository
{
    internal class SupplierRepository
    {
        private static readonly InventoryContext _context;


        static SupplierRepository()
        {
            _context = InventoryContext.GetContext();
        }

        public static List<Supplier> GetAll()
        {
            var supplierList = _context.Suppliers.ToList();
            if (supplierList.Count > 0)
                return supplierList;
            throw new DatabaseEmptyException("No supplier records in database !");

        }

        public static Supplier GetSupplierDetails(int supplierId)
        {
            var supplier = GetById(supplierId);
            if (supplier != null)
                return supplier;
            throw new IdNotFoundException("No supplier with the specified Id !");
        }

        public static void Add(Supplier supplier)
        {
            var newSupplier = GetByName(supplier.SupplierName.ToLower());
            if (newSupplier != null)
                throw new SameRecordFoundException("A supplier of the same name exists");
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

        }

        public static void Update(Supplier supplier)
        {
            var newSupplier = GetByName(supplier.SupplierName.ToLower());
            if (newSupplier != null)
                throw new SameRecordFoundException("A Supplier of the same name exists");
            _context.Entry(supplier).State = EntityState.Detached;
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
        }


        public static string Delete(int id)
        {
            var supplier = GetById(id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
                return "Deleted!";
            }
            throw new IdNotFoundException("No supplier found with the specified Id !");
        }

        public static Supplier GetById(int id)
        {
            return _context.Suppliers.Where(x => x.SupplierID == id).FirstOrDefault();

        }

        public static Supplier GetByName(string name)
        {
            var product = _context.Suppliers.Where(x => x.SupplierName.ToLower() == name).FirstOrDefault();
            if (product != null)
                _context.Entry(product).State = EntityState.Detached;
            return product;

        }


    }
}
