using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacoesCalper.Domain.Entities;
using AvaliacoesCalper.Infra.Data.EntityConfig;

namespace AvaliacoesCalper.Infra.Data.Context
{
    class AvaliacoesContext : DbContext
    {
        public AvaliacoesContext() : base("AvaliacoesDb")
        {

        }

        public DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Removing Convetions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Making sure that the implementation of the Id property in my abstract class
            //become the primary key of the table
            modelBuilder.Properties()
                .Where(p => p.Name == "Id")
                .Configure(p => p.IsKey());

            //Initial restrictions parameters for the database column
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UsersConfiguration());
        }

        //Overriding the SaveChanges() so it will save the DateIncluded and Update the DateAltered
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where
                                                (
                                                    entry =>
                                                    entry.Entity.GetType().GetProperty("DateIncluded") != null &&
                                                    entry.Entity.GetType().GetProperty("DateAltered") != null
                                                )
                    )
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateIncluded").CurrentValue = DateTime.Now;
                    entry.Property("DateAltered").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DateIncluded").IsModified = false;
                    entry.Property("DateAltered").CurrentValue = DateTime.Now;

                }

            }
            return base.SaveChanges();
        }
    }
}

