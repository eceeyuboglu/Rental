using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class HomeDetailDto : IDto
    {
        public int HomeId { get; set; }
        public int LocationId { get; set; }
        public int FindexScoreId { get; set; }
        public int FindexScore { get; set; }
        public int CategoryId { get; set; }
        public int HostId { get; set; }
        public int AmenityId { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string CategoryName { get; set; }
        public string HostName { get; set; }
        public string HostSurname { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string HostCity { get; set; }
        public string AmenityName { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int HomeFindex { get; set; }
        public int BedroomCount { get; set; }
        public int BathroomCount { get; set; }
        public DateTime HomeImageDate { get; set; }
        public string ImagePath { get; set; }

        
    }
}
