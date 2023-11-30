// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Microsoft.EntityFrameworkCore;

CarManager carManager = new CarManager(new EfCarDal());

foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.Name);
}