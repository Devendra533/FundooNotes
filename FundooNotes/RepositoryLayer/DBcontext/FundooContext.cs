using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.DBcontext
{
    public class FundooContext : DbContext
    {
        public FundooContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Entity.User> Users { get; set; }
        public DbSet<Entity.Note> Notes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Entity.User>()
            .HasIndex(u => u.Email)
            .IsUnique();
        }
    }
}
