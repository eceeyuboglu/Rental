using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class HostImage : IEntity
    {
        [Key]
        public int HostImageId { get; set; }
        public int HostId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }


    }
}
