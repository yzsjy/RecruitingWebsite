using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopJobs.DatabaseContext
{
    public class JobseekerContext : System.Data.Entity.DbContext
    {
        public JobseekerContext():base("DefaultConnection")
        {

        }
        public System.Data.Entity.DbSet<TopJobs.Models.Create> Resumes { get; set; }

    }
}