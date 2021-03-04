using Business.Concrete;
using DataAccess.Concrete.Framework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            carManager.Add(new Entities.Concrete.Car { Id=6, BrandId=1, CarName="Hızlı", ColorId=2, DailyPrice=0, Description="Sports", ModelYear="2017"});
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
