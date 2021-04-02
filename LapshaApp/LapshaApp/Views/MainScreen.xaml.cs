using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LapshaApp
{
    [DesignTimeVisible(false)]
    public partial class MainScreen : ContentPage
    {
        public MainScreen()
        {
            InitializeComponent();
            this.BindingContext = this;            
        }
        public ObservableCollection<TestDay> TestDays { get => GetTestDays(); }
       
        private ObservableCollection<TestDay> GetTestDays()
        {
            ObservableCollection<TestDay> days = new ObservableCollection<TestDay>
            {
                new TestDay
                {
                    DayName = "Monday", TestMeals = new ObservableCollection<TestMeal>
                    { 
                        new TestMeal 
                        {
                            MealNum = 1, TestProducts = new ObservableCollection<TestProduct>
                            {
                                new TestProduct {ProductName = "Potato", ProductWeight = 100},
                                new TestProduct {ProductName = "Tomato", ProductWeight = 150}
                            }
                        },
                        new TestMeal
                        {
                            MealNum = 2, TestProducts = new ObservableCollection<TestProduct>
                            {
                                new TestProduct {ProductName = "Egg", ProductWeight = 55},
                                new TestProduct {ProductName = "Salad", ProductWeight = 300}
                            }
                        }
                    } 
                },
                new TestDay
                {
                    DayName = "Tuesday", TestMeals = new ObservableCollection<TestMeal>
                    {
                        new TestMeal
                        {
                            MealNum = 1, TestProducts = new ObservableCollection<TestProduct>
                            {
                                new TestProduct {ProductName = "Potato", ProductWeight = 100},
                                new TestProduct {ProductName = "Tomato", ProductWeight = 150}
                            }
                        },
                        new TestMeal
                        {
                            MealNum = 2, TestProducts = new ObservableCollection<TestProduct>
                            {
                                //new TestProduct {ProductName = "Egg", ProductWeight = 55},
                                //new TestProduct {ProductName = "Salad", ProductWeight = 300}
                            }
                        }
                    }
                },
                new TestDay
                {
                    DayName = "Wednesday", TestMeals = new ObservableCollection<TestMeal>
                    {
                        //new TestMeal
                        //{
                        //    MealNum = 1, TestProducts = new ObservableCollection<TestProduct>
                        //    {
                        //        new TestProduct {ProductName = "Potato", ProductWeight = 100},
                        //        new TestProduct {ProductName = "Tomato", ProductWeight = 150}
                        //    }
                        //},
                        new TestMeal
                        {
                            MealNum = 2, TestProducts = new ObservableCollection<TestProduct>
                            {
                                new TestProduct {ProductName = "Egg", ProductWeight = 55},
                                new TestProduct {ProductName = "Salad", ProductWeight = 300}
                            }
                        }
                    }
                },
                new TestDay
                {
                    DayName = "Thursday", TestMeals = new ObservableCollection<TestMeal>
                    {
                        //new TestMeal
                        //{
                        //    MealNum = 1, TestProducts = new ObservableCollection<TestProduct>
                        //    {
                        //        new TestProduct {ProductName = "Potato", ProductWeight = 100},
                        //        new TestProduct {ProductName = "Tomato", ProductWeight = 150}
                        //    }
                        //},
                        //new TestMeal
                        //{
                        //    MealNum = 2, TestProducts = new ObservableCollection<TestProduct>
                        //    {
                        //        new TestProduct {ProductName = "Egg", ProductWeight = 55},
                        //        new TestProduct {ProductName = "Salad", ProductWeight = 300}
                        //    }
                        //}
                    }
                },
                new TestDay
                {
                    DayName = "Friday", TestMeals = new ObservableCollection<TestMeal>
                    {
                        new TestMeal
                        {
                            MealNum = 1, TestProducts = new ObservableCollection<TestProduct>
                            {
                                new TestProduct {ProductName = "Potato", ProductWeight = 100},
                                new TestProduct {ProductName = "Tomato", ProductWeight = 150},
                                new TestProduct {ProductName = "Egg", ProductWeight = 55},
                                new TestProduct {ProductName = "Salad", ProductWeight = 300}
                            }
                        },
                        new TestMeal
                        {
                            MealNum = 2, TestProducts = new ObservableCollection<TestProduct>
                            {
                                new TestProduct {ProductName = "Egg", ProductWeight = 55},
                                new TestProduct {ProductName = "Salad", ProductWeight = 300}
                            }
                        }
                    }
                },
                new TestDay
                {
                    DayName = "Saturday", TestMeals = new ObservableCollection<TestMeal>
                    {
                        new TestMeal
                        {
                            MealNum = 1, TestProducts = new ObservableCollection<TestProduct>
                            {
                                new TestProduct {ProductName = "Potato", ProductWeight = 100},
                                new TestProduct {ProductName = "Tomato", ProductWeight = 150}
                            }
                        },
                        new TestMeal
                        {
                            MealNum = 2, TestProducts = new ObservableCollection<TestProduct>
                            {
                                new TestProduct {ProductName = "Egg", ProductWeight = 55},
                                new TestProduct {ProductName = "Salad", ProductWeight = 300}
                            }
                        }
                    }
                },
                new TestDay
                {
                    DayName = "Sunday", TestMeals = new ObservableCollection<TestMeal>
                    {
                        new TestMeal
                        {
                            MealNum = 1, TestProducts = new ObservableCollection<TestProduct>
                            {
                                new TestProduct {ProductName = "Potato", ProductWeight = 100},
                                new TestProduct {ProductName = "Tomato", ProductWeight = 150}
                            }
                        },
                        new TestMeal
                        {
                            MealNum = 2, TestProducts = new ObservableCollection<TestProduct>
                            {
                                new TestProduct {ProductName = "Egg", ProductWeight = 55},
                                new TestProduct {ProductName = "Salad", ProductWeight = 300}
                            }
                        }
                    }
                },
            };
            foreach (TestDay day in days)
            {
                day.CalculateUIHeight();
            }
            return days;
        }
        public class TestDay
        {
            public string DayName { get; set; }
            public ObservableCollection<TestMeal> TestMeals { get; set; }
            public int DayUIHeight { get; set; }
            public TestDay()
            {
                DayUIHeight = 0;
            }
            public void CalculateUIHeight()
            {
                int elements = 0;
                int spaces = 0;
                int elementsHeight = 40;
                int spacesHeight = 11;

                if (this.TestMeals.Count > 0)
                {
                    spaces = 4;
                    foreach(TestMeal meal in this.TestMeals)
                    {
                        if (meal.TestProducts.Count > 1)
                        {
                            elements += meal.TestProducts.Count;
                            spaces++;
                        }
                        else
                        {
                            elements++;
                        }
                    }
                    this.DayUIHeight += ((elements * elementsHeight) + (spaces * spacesHeight));
                }
                else
                {
                    this.DayUIHeight = 30;
                }
            }
        }
        public class TestProduct
        {
            public string ProductName { get; set; }
            public int ProductWeight { get; set; }
        }
        public class TestMeal
        {
            public int MealNum { get; set; }
            public ObservableCollection<TestProduct> TestProducts { get; set; }
        }
    }
}
