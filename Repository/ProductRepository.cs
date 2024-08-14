using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InventoryManagementSystem.Repository
{
    internal class ProductRepository
    {
        private static readonly InventoryContext _context;
        static ProductRepository()
        {
            _context = InventoryContext.GetContext();
        }

        public static List<Product> GetAll()
        {
            var listProduct = _context.Products.ToList();
            if (listProduct.Count > 0)
                return listProduct;
            throw new DatabaseEmptyException("No Product records in database !");
        }
        public static Product GetProductDetails(int productId)
        {
            (var product, var check) = GetAndCheckById(productId);
            if (check)
                return product;
            throw new IdNotFoundException("No Product with that Id !");

        }

        public static void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public static void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Detached;
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public static string Delete(int id)
        {
            (var product, var check) = GetAndCheckById(id);
            if (check)
            {
                _context.Entry(product).State = EntityState.Detached;
                _context.Products.Remove(product);
                _context.SaveChanges();
                return "Deleted!";
            }
            throw new IdNotFoundException("No Product found with the specified Id !");
        }

        public static (Product, bool) GetAndCheckById(int id)
        {
            var product = _context.Products.Where(x => x.ProductID == id).FirstOrDefault();
            return (product, product != null)!;
        }

        public static (Product, bool) GetAndCheckByName(string name)
        {
            var product = _context.Products.Where(x => x.ProductName.ToLower() == name.ToLower()).FirstOrDefault();
            var check = product != null;
            if (check)
                _context.Entry(product).State = EntityState.Detached;
            return (product, check)!;
        }

        public static Product CheckIdUpdate(int id)
        {
            (var product, var check) = GetAndCheckById(id);
            if (check)
            {
                _context.Entry(product).State = EntityState.Detached;
                return product;
            }
            throw new IdNotFoundException("No Product exists with that Id !");

        }

        public static bool CheckNameAdd(string name)
        {
            (var product, var check) = GetAndCheckByName(name);
            if (!check)
                return true;
            throw new SameRecordFoundException("There is a record with the same Name !");
        }

        public static void CheckEnoughQuantityExists(Product product, double quantity)
        {
            if (quantity > product.Quantity)
                throw new NotEnoughQuantityExistsException("The Quantity you tried to remove is greater than present stock !");
        }



    }
}
