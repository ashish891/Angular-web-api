using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class OurDbContext:DbContext
    {
        public DbSet<ADetail> Dbdetail { get; set; }
        public DbSet<ASpecl> Dbspecl { get; set; }
        public DbSet<ViewData> Dbdata { get; set; }
    }
}