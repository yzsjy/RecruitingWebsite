using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopJobs.DatabaseContext
{
    public class EmployerContext : System.Data.Entity.DbContext
    {
        public EmployerContext() : base("DefaultConnection")
        {

        }
        public System.Data.Entity.DbSet<TopJobs.Models.Post> Jobs { get; set; }

        public System.Data.Entity.DbSet<TopJobs.Models.Submit> Submits { get; set; }
    }
}