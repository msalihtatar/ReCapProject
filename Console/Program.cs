using Business.Concrete;
using DataAccess.Concrete.Framework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();

            //GetCarDetailsTest();

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            string[] customers = { "Ateş Holding", "Su Holding", "Hava Holding" };
            for (int i = 1; i < 4; i++)
            {
                Customer customer = new Customer { Id = i, CompanyName = customers[i-1], UserId = i };

                var result = customerManager.Add(customer);
            }
        }

        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " / " + car.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color1 = new Color
            {
                ColorId = 6,
                ColorName = "Fuşya"
            };

            colorManager.Add(color1);

            var result = colorManager.GetById(2);

            Console.WriteLine(result.Data.ColorName);

            Console.WriteLine("**********************");
            Console.ReadLine();

            var result1 = colorManager.GetAll();
            foreach (var color in result1.Data)
            {
                Console.WriteLine(color.ColorId + " / " + color.ColorName);
            }

            Console.WriteLine("**********************");
            Console.ReadLine();

            color1.ColorName = "Yeşil";

            colorManager.Update(color1);
            var result2 = colorManager.GetAll();
            foreach (var color in result2.Data)
            {
                Console.WriteLine(color.ColorId + " / " + color.ColorName);
            }

            Console.WriteLine("**********************");
            Console.ReadLine();

            colorManager.Delete(color1);
            var result3 = colorManager.GetAll();
            foreach (var color in result3.Data)
            {
                Console.WriteLine(color.ColorId + " / " + color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand1 = new Brand
            {
                BrandId = 6,
                BrandName = "Mustang"
            };

            brandManager.Add(brand1);

            var result = brandManager.GetById(2);

            Console.WriteLine(result.Data.BrandName);

            Console.WriteLine("**********************");
            Console.ReadLine();
            
            var result1 = brandManager.GetAll();

            foreach (var brand in result1.Data)
            {
                Console.WriteLine(brand.BrandId + " / " + brand.BrandName);
            }

            Console.WriteLine("**********************");
            Console.ReadLine();

            brand1.BrandName = "Tofaş";

            brandManager.Update(brand1);
            var result2 = brandManager.GetAll();
            foreach (var brand in result2.Data)
            {
                Console.WriteLine(brand.BrandId + " / " + brand.BrandName);
            }

            Console.WriteLine("**********************");
            Console.ReadLine();

            brandManager.Delete(brand1);
            var result3 = brandManager.GetAll();
            foreach (var brand in result3.Data)
            {
                Console.WriteLine(brand.BrandId + " / " + brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car
            {
                Id = 6,
                BrandId = 1,
                CarName = "Hızlı",
                ColorId = 2,
                DailyPrice = 500,
                Description = "Sports",
                ModelYear = "2017"
            };

            carManager.Add(car1);
            
            var result = carManager.GetById(2);

            Console.WriteLine(result.Data.CarName);

            Console.WriteLine("**********************");
            Console.ReadLine();
            var result1 = carManager.GetAll();
            foreach (var car in result1.Data)
            {
                Console.WriteLine(car.Id + " / " + car.CarName);
            }

            Console.WriteLine("**********************");
            Console.ReadLine();

            car1.CarName = "Yavas";

            carManager.Update(car1);
            var result2 = carManager.GetAll();
            foreach (var car in result2.Data)
            {
                Console.WriteLine(car.Id + " / " + car.CarName);
            }

            Console.WriteLine("**********************");
            Console.ReadLine();

            carManager.Delete(car1);
            var result3 = carManager.GetAll();
            foreach (var car in result3.Data)
            {
                Console.WriteLine(car.Id + " / " + car.CarName);
            }
        }
    }
}
