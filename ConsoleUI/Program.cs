// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

CarManager carManager = new CarManager(new EfCarDal());

foreach (var car in carManager.GetAllByBrandId(1))
{
    Console.WriteLine(car.Name);
}

Car car1 = new Car {BrandId = 2, ColorId = 3, DailyPrice = 300, ModelYear = 2024, Name = "RS7", Description = "spor" };
Car car2 = new Car {BrandId = 2, ColorId = 3, DailyPrice = 0, ModelYear = 2024, Name = "RS7", Description = "spor" };
carManager.Add(car2);