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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (CarRentDbContext carRentDbContext = new CarRentDbContext())
            {
                var addedCar = carRentDbContext.Entry(entity);
                addedCar.State = EntityState.Added;
                carRentDbContext.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (CarRentDbContext carRentDbContext = new CarRentDbContext())
            {
                var deletedCar = carRentDbContext.Entry(entity);
                deletedCar.State = EntityState.Deleted;
                carRentDbContext.SaveChanges();
            }
        }

        public List<Color> GetAll(Expression<Func<Color,bool>> filter=null)
        {
            using (CarRentDbContext carRentDbContext = new CarRentDbContext())
            {
                return filter == null ? carRentDbContext.Set<Color>().ToList() : carRentDbContext.Set<Color>().Where(filter).ToList();
            }
        }

        public Color GetById(Expression<Func<Color, bool>> filter)
        {
            using (CarRentDbContext context = new CarRentDbContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public void Update(Color entity)
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
