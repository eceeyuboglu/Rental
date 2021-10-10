using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Home : IEntity
    {
        public int HomeId { get; set; }
        public int LocationId { get; set; }
        public int CategoryId { get; set; }
        public int HostId { get; set; }
        public int AmenityId { get; set; }
        
        public int DailyPrice { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int FindexScoreId { get; set; }
        public int HomeFindex { get; set; }
        public int BedroomCount { get; set; }
        public int BathroomCount { get; set; }
        
        
    }
}
