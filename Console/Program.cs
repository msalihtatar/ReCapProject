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

            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
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

            Console.WriteLine(result.ColorName);

            Console.WriteLine("**********************");
            Console.ReadLine();

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + " / " + color.ColorName);
            }

            Console.WriteLine("**********************");
            Console.ReadLine();

            color1.ColorName = "Yeşil";

            colorManager.Update(color1);
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + " / " + color.ColorName);
            }

            Console.WriteLine("**********************");
            Console.ReadLine();

            colorManager.Delete(color1);
            foreach (var color in colorManager.GetAll())
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

            Console.WriteLine(result.BrandName);

            Console.WriteLine("**********************");
            Console.ReadLine();

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + " / " + brand.BrandName);
            }

            Console.WriteLine("**********************");
            Console.ReadLine();

            brand1.BrandName = "Tofaş";

            brandManager.Update(brand1);
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + " / " + brand.BrandName);
            }

            Console.WriteLine("**********************");
            Console.ReadLine();

            brandManager.Delete(brand1);
            foreach (var brand in brandManager.GetAll())
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

            Console.WriteLine(result.CarName);

            Console.WriteLine("**********************");
            Console.ReadLine();

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " / " + car.CarName);
            }

            Console.WriteLine("**********************");
            Console.ReadLine();

            car1.CarName = "Yavas";

            carManager.Update(car1);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " / " + car.CarName);
            }

            Console.WriteLine("**********************");
            Console.ReadLine();

            carManager.Delete(car1);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " / " + car.CarName);
            }
        }
    }
}
