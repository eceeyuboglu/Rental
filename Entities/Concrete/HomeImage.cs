using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class HomeImage : IEntity
    {
        [Key]
        public int HomeImageId { get; set; }
        public int HomeId { get; set; }
        public string ImagePath { get; set; }
        public DateTime HomeImageDate { get; set; }

        
    }
}
