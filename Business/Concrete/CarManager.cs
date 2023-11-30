using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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

        public List<Car> GetAll()
        {
           return _iCarDal.GetAll();
        }

        public List<Car> GetAllByCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByUnitPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }
    }
}
