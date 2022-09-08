using FluentValidation.Validators;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public DbSet<ProgrammingTechnology> ProgrammingTechnologies { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(x =>
            {
                x.ToTable("ProgrammingLanguages").HasKey(p => p.Id);
                x.Property(p => p.Id).HasColumnName("Id");
                x.Property(p => p.Name).HasColumnName("Name");

                x.HasMany(p => p.ProgrammingTechnologies);
            });

            modelBuilder.Entity<ProgrammingTechnology>(x =>
            {
                x.ToTable("ProgrammingTechnologies").HasKey(p => p.Id);
                x.Property(p => p.Id).HasColumnName("Id");
                x.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                x.Property(p => p.Name).HasColumnName("Name");

                x.HasOne(p => p.ProgrammingLanguage);
            });

            ProgrammingLanguage[] programmingLanguageEntitySeed =
            {
                new(1, "C#"),
                new(2, "Java")
            };

            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeed);

            ProgrammingTechnology[] programmingTechnologyEntitySeed =
            {
                new (1,1,"ASP.NET"),
                new (2,2,"Spring")
            };

            modelBuilder.Entity<ProgrammingTechnology>().HasData(programmingTechnologyEntitySeed);
        }
    }
}
