using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        public static void RentAHome(User user, Home home, Customer customer)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental();
            rental.HomeId = home.HomeId;
            rental.CustomerId = customer.CustomerId;
            rental.RentDate = DateTime.Now;
            rental.ReturnDate = null;
            var result = rentalManager.Add(rental);
            Console.WriteLine(result.Message);
        }
    }
}
