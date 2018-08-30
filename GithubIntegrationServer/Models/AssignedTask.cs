using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GithubIntegrationServer.Models
{
    public class AssignedTask
    {
        [Key]
        public int TaskId { get; set; }
        public string GroupName { get; set; }
        public string TaskName { get; set; }
        public string TaskAssigned { get; set; }
        public DateTime TaskTimeStamp { get; set; }
        [DefaultValue(false)]
        public bool TaskIsCompleted { get; set; }
    }
}
