using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int RentalId { get; set; }
        public int CardId { get; set; }
        public int CustomerId { get; set; }
        public int CategoryId { get; set; }
        public int HomeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime RentDate { get; set; }

    }
}
