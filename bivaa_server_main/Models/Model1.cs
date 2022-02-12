using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace bivaa_server_main.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ModelMarketa")
        {
        }

        public virtual DbSet<items> items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<items>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<items>()
                .Property(e => e.company)
                .IsUnicode(false);
        }
    }
}
