using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class HomeImageDto : IDto
    {
        public int ImageId { get; set; }
        public int HomeId { get; set; }
        
        public IFormFile ImageFile { get; set; }
    }
}
