using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspNetTestProject.DAL
{
    public class DbEntities : DbContext
    {
        public DbEntities()
            : base("DefaultConnection")
        {

        }

        public static DbEntities Create()
        {
            return new DbEntities();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            base.OnModelCreating(modelBuilder);
            
        }

        public DbSet<Task> Tasks { get; set; }
    }
}