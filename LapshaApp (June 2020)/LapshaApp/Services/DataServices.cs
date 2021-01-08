using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LapshaApp
{
    public static class DataServices
    {
        public static void AddProductToDB(string dbPath, Product product)
        {
            if (product != null)
            {
                try
                {
                    using (var db = new ApplicationContext(dbPath))
                    {
                        if (product.Id == 0)
                            db.Products.Add(product);
                        else
                        {
                            db.Products.Update(product);
                        }                        
                        db.SaveChanges();
                    }
                }
                catch(Exception e)
                {

                }
            }
        }
        public static void AddProductToDay(string dbPath, string productName, string dayName, double wght)
        {
            try
            {
                using (var db = new ApplicationContext(dbPath))
                {
                    var prod = db.Products.FirstOrDefault(p => p.productName == productName);
                    var day = db.Days.FirstOrDefault(d => d.dayName == dayName);
                    Product buf = new Product();

                    buf.prot = prod.prot;
                    buf.fat = prod.fat;
                    buf.carb = prod.carb;
                    buf.calorie = prod.calorie;
                    buf.Calculate(wght);

                    if (prod != null && day != null)
                    {                        
                        day.ProductDays.Add(new ProductDay{ productId = prod.Id, dayId = day.Id, weight = wght });
                        day.totalProt       += buf.prot;
                        day.totalFat        += buf.fat;
                        day.totalCarb       += buf.carb;
                        day.totalCalorie    += buf.calorie;

                        db.SaveChanges();
                    }                                       
                }
            }
            catch (Exception e)
            {

            }            
        }
        public static void DeleteProductFromDay(string dbPath, string productName, string dayName)
        {
            try
            {
                using (var db = new ApplicationContext(dbPath))
                {
                    var day = db.Days.Include(d => d.ProductDays).FirstOrDefault(d => d.dayName == dayName);
                    var prod = db.Products.FirstOrDefault(p => p.productName == productName);
                    var productDays = day.ProductDays.FirstOrDefault(pd => pd.productId == prod.Id);
                    Product buf = new Product();

                    buf.prot = prod.prot;
                    buf.fat = prod.fat;
                    buf.carb = prod.carb;
                    buf.calorie = prod.calorie;
                    buf.Calculate(productDays.weight);

                    if (prod != null && day != null)
                    {                        
                        day.ProductDays.Remove(productDays);
                        day.totalProt       -= buf.prot;
                        day.totalFat        -= buf.fat;
                        day.totalCarb       -= buf.carb;
                        day.totalCalorie    -= buf.calorie;

                        db.SaveChanges();
                    }
                }                
            }
            catch(Exception e)
            {

            }
        }
        public static List<Product> GetAllProducts(string dbPath)
        {
            try
            {
                using (var db = new ApplicationContext(dbPath))
                {
                    var prList = db.Products.ToList();
                    return prList;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //Get list of products for selected Day
        public static List<Product> GetDaylyProducts(string dbPath, string dName)
        {
            List<Product> daylyProducts = new List<Product>();

            using (var db=new ApplicationContext(dbPath))
            {
                var curDay = db.Days.Where(d => d.dayName == dName).Include(c => c.ProductDays).ThenInclude(sc => sc.Product).FirstOrDefault();
                daylyProducts = curDay.ProductDays.Select(p => p.Product).ToList();
            }
            
            return daylyProducts;
        }
        public static List<Product> GetDaylyCalculatedProducts(string dbPath, string dName)
        {

            List<Product> products = new List<Product>();

            products = DataServices.GetDaylyProducts(dbPath, dName);
            

            using (var db=new ApplicationContext(dbPath))
            {
                
                var curDay = db.Days.FirstOrDefault(d => d.dayName == dName);
                foreach (var prod in products)
                {
                    prod.weight = curDay.GetProductWeight(dbPath, prod.productName);
                    prod.Calculate(prod.weight);
                }
            }

            return products;
        }
        public static Day GetDay(string dbPath, string dName)
        {
            Day curDay = new Day();
            using (var db = new ApplicationContext(dbPath))
            {
                curDay = db.Days.Where(d => d.dayName == dName).Include(c => c.ProductDays).ThenInclude(sc => sc.Product).FirstOrDefault();
            }
            return curDay;
        }              
    }
}

