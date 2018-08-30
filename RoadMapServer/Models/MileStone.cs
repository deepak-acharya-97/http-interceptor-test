using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoadMapServer.Models
{
    public class MileStone
    {
        public int MileStoneId { get; set; }
        public string MileStoneName { get; set; }
        [DefaultValue(false)]
        public bool MileStoneIsCompleted { get; set; }
        public DateTime MileStoneTimeStamp { get; set; }
    }
}
