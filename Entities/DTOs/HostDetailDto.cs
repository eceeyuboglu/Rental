using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class HostDetailDto :IDto
    {
        public int HostId { get; set; }
        public string HostName { get; set; }
        public string HostSurname { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string HostCity { get; set; }
    }
}
