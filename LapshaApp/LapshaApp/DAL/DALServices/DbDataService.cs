using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;



namespace LapshaApp
{
    public static class DbDataService
    {
        #region Work with Days

        public static Day GetDayFormDb(string dayName)
        {
            try
            {
                Day buf = new Day();

                using (var db = new ApplicationContext(Constants.DbPath))
                {
                    buf = db.Days
                        .Where(d => d.DayName == dayName)
                        .Include(m => m.Meals)
                        .ThenInclude(pm => pm.ProductMeals)
                        .ThenInclude(p => p.Product)
                        .FirstOrDefault();
                }

                return buf;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Day> GetAllDaysFromDb()
        {
            try
            {
                using (var db = new ApplicationContext(Constants.DbPath))
                {
                    var dayList = db.Days
                        .Include(m => m.Meals)
                        .ThenInclude(pm => pm.ProductMeals)
                        .ThenInclude(p => p.Product)
                        .ToList();

                    return dayList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region Work with Meals



        #endregion        

        #region Work with Recipes

        public static Recipe GetRecipeFromDb(long productId)
        {
            try
            {
                Recipe buf = new Recipe();

                using (var db = new ApplicationContext(Constants.DbPath))
                {
                    buf = db.Recipes
                        .Where(r => r.ProductId == productId)
                        .Include(pr => pr.ProductRecipes)
                        .ThenInclude(p => p.Product)
                        .FirstOrDefault();
                }

                return buf;
            }
            catch (Exception)
            {
                return null;
            }            
        }

        #endregion

        #region Work with Products

        public static Product GetProductFromDb(string productName)
        {
            try
            {
                Product buf = new Product();

                using (var db = new ApplicationContext(Constants.DbPath))
                {
                    buf = db.Products
                        .Where(p => p.ProductName == productName)
                        .FirstOrDefault();
                }

                return buf;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public static List<Product> GetAllProductsFromDb()
        {
            try
            {
                using (var db = new ApplicationContext(Constants.DbPath))
                {
                    var productList = db.Products
                        .ToList();

                    return productList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void AddProductToDb(Product product)
        {
            if (product != null)
            {
                try
                {
                    using (var db = new ApplicationContext(Constants.DbPath))
                    {
                        if (product.ProductId == 0)
                            db.Products
                                .Add(product);
                        else
                        {
                            db.Products
                                .Update(product);
                        }
                        db.SaveChanges();
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        //нужно будет тестить на предмет каскадного удаления. Надо будет проверить удаляется или нет из Days и Meals
        public static void DeleteProductFromDb(string productName)
        {
            if (productName != null)
            {
                try
                {
                    using(var db=new ApplicationContext(Constants.DbPath))
                    {
                        var product = db.Products
                            .FirstOrDefault(p => p.ProductName == productName);

                        db.Products
                            .Remove(product);
                        db.SaveChanges();
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        public static void AddProductToMeal(string productName, long mealName, string dayName, int weight)
        {
            try
            {
                using (var db = new ApplicationContext(Constants.DbPath))
                {
                    var product = db.Products
                        .FirstOrDefault(p => p.ProductName == productName);
                    var day = db.Days
                        .Include(m => m.Meals)
                        .ThenInclude(pm=>pm.ProductMeals)
                        .FirstOrDefault(d => d.DayName == dayName);
                    var meal = day.Meals
                        .Where(m => m.MealName == mealName)
                        .FirstOrDefault();

                    if (product != null && day != null && meal != null)
                    {
                        product.Calculate(weight);

                        meal.ProductMeals.Add(new ProductMeal
                        {
                            ProductId = product.ProductId,
                            MealId = meal.MealId,
                            ProductWeight = weight
                        });
                        meal.MealProt += product.ProductProt;
                        meal.MealFat += product.ProductFat;
                        meal.MealCarb += product.ProductCarb;
                        meal.MealCalories += product.ProductCalories;

                        day.Prot += product.ProductProt;
                        day.Fat += product.ProductFat;
                        day.Carb += product.ProductCarb;
                        day.Calorie += product.ProductCalories;

                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        //Перепилить, копипаста
        //public static void DeleteProductFromMeal(string productName, long mealName, string dayName)
        //{
        //
        //    try
        //    {
        //        using (var db = new ApplicationContext(Constants.DbPath))
        //        {
        //            var product = db.Products
        //                .FirstOrDefault(p => p.ProductName == productName);
        //            var day = db.Days
        //                .Include(m => m.Meals)
        //                .FirstOrDefault(d => d.DayName == dayName);
        //            var meal = day.Meals
        //                .Where(m => m.MealName == mealName)
        //                .FirstOrDefault();
        //
        //            if (product != null && day != null && meal != null)
        //            {
        //                product.Calculate(weight);
        //
        //                meal.ProductMeals.Add(new ProductMeal
        //                {
        //                    ProductId = product.ProductId,
        //                    MealId = meal.MealId,
        //                    ProductWeight = weight
        //                });
        //                meal.MealProt += product.ProductProt;
        //                meal.MealFat += product.ProductFat;
        //                meal.MealCarb += product.ProductCarb;
        //                meal.MealCalories += product.ProductCalories;
        //
        //                day.Prot += product.ProductProt;
        //                day.Fat += product.ProductFat;
        //                day.Carb += product.ProductCarb;
        //                day.Calorie += product.ProductCalories;
        //
        //                db.SaveChanges();
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //
        //    }
        //}

        #endregion
    }
}
