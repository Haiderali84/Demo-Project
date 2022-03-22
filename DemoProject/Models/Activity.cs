using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string ActivityDescription { get; set; }
        public string ActivityTime { get; set; }
        public int PriorityId { get; set; }
        public string Priority { get; set; }


    }
}
