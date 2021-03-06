using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars; //Manuel Database
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car { Id=1, BrandId=1960, ColorId=1, DailyPrice=100000, Description="Sedan", ModelYear="2017"},
                new Car { Id=2, BrandId=1970, ColorId=1, DailyPrice=140000, Description="SUV", ModelYear="2015"},
                new Car { Id=3, BrandId=1980, ColorId=2, DailyPrice=130000, Description="Coupe", ModelYear="2017"},
                new Car { Id=4, BrandId=2020, ColorId=1, DailyPrice=200000, Description="Hybrid", ModelYear="2019"},
                new Car { Id=5, BrandId=1950, ColorId=5, DailyPrice=150000, Description="Minivan", ModelYear="2020"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car _carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(_carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.Find(c => c.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car _carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            _carToUpdate.BrandId = car.BrandId;
            _carToUpdate.ColorId = car.ColorId;
            _carToUpdate.DailyPrice = car.DailyPrice;
            _carToUpdate.Description = car.Description;
            _carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
