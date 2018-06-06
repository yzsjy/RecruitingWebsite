using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopJobs.DatabaseContext
{
    public class ResumeContext : System.Data.Entity.DbContext
    {
        public ResumeContext() : base("DefaultConnection")
        {

        }
        public System.Data.Entity.DbSet<TopJobs.Models.Submit> SubmitResume { get; set; }

    }
}