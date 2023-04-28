﻿using System;
using JwtApp.Core.Domain;
using JwtApp.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JwtApp.Persistance.Context
{
    public class JwtAppContext : DbContext
    {
        public JwtAppContext(DbContextOptions<JwtAppContext> options) : base(options)
        {
        }

        public DbSet<Product> Products => this.Set<Product>();

        public DbSet<Category> Categories => this.Set<Category>();

        public DbSet<AppUser> AppUsers => this.Set<AppUser>();

        public DbSet<AppRole> AppRoles => this.Set<AppRole>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

