using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentContext>, ICustomerDal
    {
        public CustomerDetailDto getCustomerByEmail(Expression<Func<CustomerDetailDto, bool>> filter)
        {
            using (RentContext context = new RentContext())
            {
                var result = from customer in context.Customer
                             join user in context.User
                                 on customer.UserId equals user.UserId
                             select new CustomerDetailDto
                             {
                                 CustomerId = customer.CustomerId,
                                 UserId = user.UserId,
                                 Name = user.FirstName,
                                 Surname = user.LastName,
                                 Email = user.Email,
                                 CustomerFindex = (int)customer.CustomerFindex
                             };
                return result.SingleOrDefault(filter);
            }
        }

        public List<CustomerDetailDto> GetCustomerDetail(Expression<Func<Customer, bool>> filter = null)
        {
            using (RentContext context = new RentContext())
            {
                var result = from customer in filter == null ? context.Customer : context.Customer.Where(filter)
                             join u in context.User
                             on customer.UserId equals u.UserId
                             select new CustomerDetailDto
                             {
                                 CustomerId = customer.CustomerId,
                                 UserId = u.UserId,
                                 Name = u.FirstName,
                                 Surname = u.LastName,
                                 Email = u.Email,
                                 CustomerFindex = (int)customer.CustomerFindex
                             };
                return result.ToList();
            }
        }
    }
}
