using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {Id=1, BrandId=1, ColorId=2, DailyPrice=200, Description="temiz araba", ModelYear = 2010, Name="fiat"},
                new Car {Id=2, BrandId=2, ColorId=3, DailyPrice=400, Description="temiz araba", ModelYear = 2020, Name="bmw"},
                new Car {Id=3, BrandId=2, ColorId=4, DailyPrice=300, Description="temiz araba", ModelYear = 2013, Name="bmw"},
                new Car {Id=4, BrandId=1, ColorId=4, DailyPrice=100, Description="temiz araba", ModelYear = 2015, Name="opel"}
        };
        }
            
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
           Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
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

        public Car GetById(Car car)
        {
            Car carToGet = _cars.FirstOrDefault(c => c.Id == car.Id);
            return carToGet;
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear; 
            carToUpdate.Name = car.Name;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
        }

    }
}
