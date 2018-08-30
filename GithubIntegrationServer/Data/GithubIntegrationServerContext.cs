using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GithubIntegrationServer.Models
{
    public class GithubIntegrationServerContext : DbContext
    {
        public GithubIntegrationServerContext (DbContextOptions<GithubIntegrationServerContext> options)
            : base(options)
        {
        }

        public DbSet<GithubIntegrationServer.Models.AssignedTask> AssignedTask { get; set; }
    }
}
