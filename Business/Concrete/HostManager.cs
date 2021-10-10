using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class HostManager :IHostService
    {
        IHostDal _hostDal;
        public HostManager(IHostDal hostDal)
        {
            _hostDal = hostDal;
        }

        public IResult Add(Host host)
        {
            _hostDal.Add(host);
            return new SuccessResult(Messages.HostAdded);
        }

        public IResult Delete(Host host)
        {
            _hostDal.Delete(host);
            return new SuccessResult(Messages.HostDeleted);
        }

        public IDataResult<List<Host>> GetAll()
        {
            return new SuccessDataResult<List<Host>>(_hostDal.GetAll(), Messages.HostListed);
        }

        public IDataResult<Host> GetById(int colorId)
        {
            return new SuccessDataResult<Host>(_hostDal.Get(c => c.HostId == colorId));
        }

        public IResult Update(Host host)
        {
            _hostDal.Update(host);
            return new SuccessResult(Messages.HostUpdated);
        }
    }
}
