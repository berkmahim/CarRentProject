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
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (CarRentDbContext context = new CarRentDbContext())
            {
                var addedCar = context.Entry(entity);
                addedCar.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (CarRentDbContext context = new CarRentDbContext())
            {
                var deletedCar = context.Entry(entity);
                deletedCar.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (CarRentDbContext context = new CarRentDbContext())
            {
                return filter == null ? context.Set<Brand>().ToList() : context.Set<Brand>().Where(filter).ToList();

            }
        }

        public Brand GetById(Expression<Func<Brand, bool>> filter)
        {
            using (CarRentDbContext context = new CarRentDbContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public void Update(Brand entity)
        {
            using (CarRentDbContext context = new CarRentDbContext())
            {
                var updatedCar = context.Entry(entity);
                updatedCar.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
