using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Rental : IEntity
    {
        [Key]
        public int RentalId { get; set; }
        public int CardId { get; set; }
        public int CustomerId { get; set; }
        public int HomeId { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime RentDate { get; set; }
    }
}
