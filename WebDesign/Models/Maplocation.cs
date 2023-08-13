using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebDesign.Models
{
    public partial class Maplocation : DbContext
    {
        public Maplocation()
            : base("name=Maplocation")
        {
        }

        public virtual DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.Latitude)
                .HasPrecision(10, 8);

            modelBuilder.Entity<Location>()
                .Property(e => e.Longitude)
                .HasPrecision(11, 8);
        }
    }
}
