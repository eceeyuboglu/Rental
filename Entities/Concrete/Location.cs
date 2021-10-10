using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Location : IEntity
    {
        public int LocationId { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string District { get; set; }

    }
}
