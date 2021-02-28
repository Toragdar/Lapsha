using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LapshaApp
{
    public static class AppService
    {
        public static async void TestDbFilling()
        {

            try
            {
                using (var db = new ApplicationContext(Constants.DbPath))
                {
                    List<Day> days = new List<Day>();
                    List<Product> products = new List<Product>();

                    #region Days to Add

                    days.Add(new Day { 
                        DayName = "Понедельник", 
                        Prot = 0, 
                        Fat = 0, 
                        Carb = 0, 
                        Calorie = 0 
                    });
                    days.Add(new Day { 
                        DayName = "Вторник", 
                        Prot = 0, 
                        Fat = 0, 
                        Carb = 0, 
                        Calorie = 0 
                    });
                    days.Add(new Day { 
                        DayName = "Среда", 
                        Prot = 0, 
                        Fat = 0, 
                        Carb = 0, 
                        Calorie = 0 
                    });
                    days.Add(new Day { 
                        DayName = "Четверг", 
                        Prot = 0, 
                        Fat = 0, 
                        Carb = 0, 
                        Calorie = 0 
                    });
                    days.Add(new Day { 
                        DayName = "Пятница", 
                        Prot = 0, 
                        Fat = 0, 
                        Carb = 0, 
                        Calorie = 0 
                    });
                    days.Add(new Day { 
                        DayName = "Суббота", 
                        Prot = 0, 
                        Fat = 0, 
                        Carb = 0, 
                        Calorie = 0 
                    });
                    days.Add(new Day { 
                        DayName = "Воскресенье", 
                        Prot = 0, 
                        Fat = 0, 
                        Carb = 0, 
                        Calorie = 0 
                    });

                    #endregion

                    #region Products to Add

                    products.Add(new Product { 
                        ProductName = "Картофель", 
                        ProductProt = 2, 
                        ProductFat = 0.4,
                        ProductCarb = 16.1,
                        ProductCalories = 76,
                        ProductCategory = "product"
                    });
                    products.Add(new Product
                    {
                        ProductName = "Свекла",
                        ProductProt = 1.5,
                        ProductFat = 0.1,
                        ProductCarb = 8.8,
                        ProductCalories = 43,
                        ProductCategory = "product"
                    });
                    products.Add(new Product
                    {
                        ProductName = "Морковь",
                        ProductProt = 1.3,
                        ProductFat = 0.1,
                        ProductCarb = 6.9,
                        ProductCalories = 32,
                        ProductCategory = "product"
                    });
                    products.Add(new Product
                    {
                        ProductName = "Лук",
                        ProductProt = 1.4,
                        ProductFat = 0,
                        ProductCarb = 10.4,
                        ProductCalories = 47,
                        ProductCategory = "product"
                    });
                    products.Add(new Product
                    {
                        ProductName = "Капуста квашеная",
                        ProductProt = 1.8,
                        ProductFat = 0.1,
                        ProductCarb = 4.4,
                        ProductCalories = 19,
                        ProductCategory = "product"
                    });
                    products.Add(new Product
                    {
                        ProductName = "Масло растительное",
                        ProductProt = 0,
                        ProductFat = 99,
                        ProductCarb = 0,
                        ProductCalories = 899,
                        ProductCategory = "product"
                    });
                    products.Add(new Product
                    {
                        ProductName = "Укроп",
                        ProductProt = 2.5,
                        ProductFat = 0.5,
                        ProductCarb = 6.3,
                        ProductCalories = 38,
                        ProductCategory = "product"
                    });

                    #endregion

                    db.Days.AddRange(days);
                    db.Products.AddRange(products);

                    await db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

            }            
        }

        public static async void FirstStartDbFilling()
        {
            
        }
    }
}
