using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RoadMapServer.Models
{
    public class RoadMapServerContext : DbContext
    {
        public RoadMapServerContext (DbContextOptions<RoadMapServerContext> options)
            : base(options)
        {
        }

        public DbSet<RoadMapServer.Models.RoadMap> RoadMap { get; set; }
    }
}
