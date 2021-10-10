using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Amenity :IEntity
    {
        public int AmenityId { get; set; }
        public string AmenityName { get; set; }
    }
}
