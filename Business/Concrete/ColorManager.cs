using Business.Abstract;
using Business.Constants;
using Core.Utilities.Reuslts;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colordal;
        public ColorManager(IColorDal colorDal)
        {
            _colordal = colorDal;
        }


        public IResult Add(Color color)
        {
            _colordal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colordal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colordal.GetAll(), Messages.ColorsListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colordal.Get(c => c.Id == id), Messages.ColorsListed);
        }

        public IResult Update(Color color)
        {
            _colordal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
