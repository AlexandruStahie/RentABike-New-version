using RentABike.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace RentABike
{
    public class Entities : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        static Entities()
        {
            Database.SetInitializer<Entities>(null);
        }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Bicycle> Bicycle { get; set; }

    }
}
