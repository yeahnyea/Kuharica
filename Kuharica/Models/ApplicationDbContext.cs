﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Kuharica.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Meal> Meals { get; set; }
    
        public ApplicationDbContext()
            : base("KuharicaContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Meal>()
                .ToTable("RecipeCategory");

            modelBuilder.Entity<Meal>()
                .Property(p => p.Type)
                .HasColumnName("Name");
        }
    }
}