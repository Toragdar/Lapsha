using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

// ADD - products, meals, recipes
// DELETE - products, meals, recipes
// UPDATE - 

//

namespace LapshaApp
{
    public static class DbDataService
    {
        public static Day GetDay(string _dayName)
        {
            Day buf = new Day();

            using (var db = new ApplicationContext(Constants.DbPath))
            {
                buf = db.Days.Where(d => d.DayName == _dayName).Include(m => m.Meals).ThenInclude(pm => pm.ProductMeals).ThenInclude(p => p.Product).FirstOrDefault();
            }

            return buf;
        }
        public static Product GetProduct (string _productName)
        {
            Product buf = new Product();

            using (var db = new ApplicationContext(Constants.DbPath))
            {
                buf = db.Products.Where(p => p.ProductName == _productName).FirstOrDefault();
            }

            return buf;
        }
        public static Recipe GetRecipe(long _productId)
        {
            Recipe buf = new Recipe();

            using(var db=new ApplicationContext(Constants.DbPath))
            {
                buf = db.Recipes.Where(r => r.ProductId == _productId).Include(pr => pr.ProductRecipes).ThenInclude(p => p.Product).FirstOrDefault();
            }

            return buf;
        }
        public static List<Day> GetAllDays()
        {
            try
            {
                using(var db=new ApplicationContext(Constants.DbPath))
                {
                    var dayList = db.Days.Include(m => m.Meals).ThenInclude(pm => pm.ProductMeals).ThenInclude(p => p.Product).ToList();

                    return dayList;
                }
            }
            catch(Exception)
            {
                return null;
            }
        }
        public static List<Product> GetAllProducts()
        {
            try
            {
                using (var db = new ApplicationContext(Constants.DbPath))
                {
                    var productList = db.Products.ToList();

                    return productList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
