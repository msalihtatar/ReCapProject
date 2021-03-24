using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IUserDal _userDal;

        public CustomerManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            var result = _userDal.Get(u => u.Id == customer.UserId);////There is a problem in here
            if (result.GetType() == typeof(int))
            {
                return new ErrorResult(Messages.InvalidUser);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Customer customer)
        {
            if (_userDal.Get(u => u.Id == customer.UserId).GetType() != typeof(User))
            {
                return new ErrorResult(Messages.InvalidUser);
            }
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.ProductAdded);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == customerId), Messages.ProductAdded);
        }

        public IResult Update(Customer customer)
        {
            if (_customerDal.Get(c => c.Id == customer.Id).GetType() != typeof(Customer))
            {
                return new ErrorResult(Messages.InvalidUser);
            }
            _customerDal.Update(customer);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
