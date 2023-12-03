using Business.Abstract;
using Business.Constants;
using Core.Utilities.Reuslts;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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

        public IResult Add(Car car)
        {
            if (car.Name.Length < 2 || car.DailyPrice <= 0)

                return new ErrorResult(Messages.InvalidCarName);

            _iCarDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _iCarDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);

        }

        public IDataResult<List<Car>>  GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintanceTime);
            }


            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.BrandId == id), Messages.CarsListed);
            // return _iCarDal.GetAll(p => p.BrandId == id);
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.ColorId == id), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(), Messages.DetailsListed);
        }

        public IResult Update(Car car)
        {
            _iCarDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

    }


    
}
