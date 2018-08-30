using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoadMapServer.Models
{
    public class RoadMap
    {
        [Key]
        public string GroupName { get; set; }
        public List<MileStone> MileStones { get; set; }
    }
}
