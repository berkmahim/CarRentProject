using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentDbContext context = new CarRentDbContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             select new CarDetailDto { 
                                 CarId = car.Id,
                                 CarName = car.Name, 
                                 BrandName = brand.Name, 
                                 ColorName = color.Name, 
                                 DailyPrice = car.DailyPrice };
                
                return result.ToList();
            }
        }
    }
}
