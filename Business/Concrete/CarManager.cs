using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _iCarDal;
        public CarManager(ICarDal carDal)
        {
           _iCarDal = carDal;
        }

        public void Add(Car car)
        {
            if(car.Name.Length < 2 || car.DailyPrice <= 0)
            
                Console.WriteLine("Yeni araç adı minimum 2 karakter olmalı ve günlük ücreti 0'dan büyük olmalıdır");
            
            else
                _iCarDal.Add(car);
        }

        public void Delete(Car car)
        {
            _iCarDal.Delete(car);
        }

        public List<Car> GetAll()
        {
           return _iCarDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _iCarDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetAllByColorId(int id)
        {
            return _iCarDal.GetAll(p => p.ColorId == id);
        }

        public List<Car> GetAllByUnitPrice(decimal min, decimal max)
        {
            return _iCarDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _iCarDal.GetCarDetails();
        }

        public void Update(Car car)
        {
            _iCarDal.Update(car);
        }
    }
}
