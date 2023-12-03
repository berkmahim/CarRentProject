// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using Core.Utilities.Reuslts;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

ColorManager colorManager =  new ColorManager(new EfColorDal());


foreach (var color in colorManager.GetAll().Data)
{
    Console.WriteLine(color.Name);
}