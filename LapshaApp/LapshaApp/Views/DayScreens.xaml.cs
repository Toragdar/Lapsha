using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LapshaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayScreens : CarouselPage
    {
        public DayScreens()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        public ObservableCollection<TestDay> TestDays { get => GetTestDays(); }
        #region MockData
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
            public double DayProt { get; set; }
            public double DayFat { get; set; }
            public double DayCarb { get; set; }
            public int DayCallories { get; set; }
            public ObservableCollection<TestMeal> TestMeals { get; set; }
            public int DayUIHeight { get; set; }
            public TestDay()
            {
                DayUIHeight = 0;
                DayProt = 0;
                DayFat = 0;
                DayCarb = 0;
                DayCallories = 0;
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
                    foreach (TestMeal meal in this.TestMeals)
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
            public double ProductProt { get; set; }
            public double ProductFat { get; set; }
            public double ProductCarb { get; set; }
            public int ProductCallories { get; set; }
            public int ProductWeight { get; set; }
            public TestProduct()
            {
                ProductProt = 0;
                ProductFat = 0;
                ProductCarb = 0;
                ProductCallories = 0;
            }
        }
        public class TestMeal
        {
            public int MealNum { get; set; }
            public double MealProt { get; set; }
            public double MealFat { get; set; }
            public double MealCarb { get; set; }
            public int MealCallories { get; set; }
            public ObservableCollection<TestProduct> TestProducts { get; set; }
            public TestMeal()
            {
                MealProt = 0;
                MealFat = 0;
                MealCarb = 0;
                MealCallories = 0;
            }
        }
        #endregion
    }
}

