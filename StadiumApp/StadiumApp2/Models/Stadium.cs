using System;
using System.Collections.Generic;
using System.Text;

namespace StadiumApp2.Models
{
    internal class Stadium
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public decimal HourlyPrice { get; set; }
        public byte Capacity { get; set; }
    }
}
