using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (CarRentDbContext carRentDbContext = new CarRentDbContext())
            {
                var addedCar = carRentDbContext.Entry(entity);
                addedCar.State = EntityState.Added;
                carRentDbContext.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (CarRentDbContext carRentDbContext = new CarRentDbContext())
            {
                var deletedCar = carRentDbContext.Entry(entity);
                deletedCar.State = EntityState.Deleted;
                carRentDbContext.SaveChanges();
            }
        }

      
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentDbContext context = new CarRentDbContext())
            {
                //return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
                
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            using (CarRentDbContext context = new CarRentDbContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public void Update(Car entity)
        {
            using (CarRentDbContext carRentDbContext = new CarRentDbContext())
            {
                var updatedCar = carRentDbContext.Entry(entity);
                updatedCar.State = EntityState.Modified;
                carRentDbContext.SaveChanges();
            }
        }
    }
}
