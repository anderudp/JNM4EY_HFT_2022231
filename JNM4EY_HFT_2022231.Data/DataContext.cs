using Endpoint;
using JNM4EY_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<AgendaUser> AgendaUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendaUser>()
                .HasKey(au => new { au.AgendaId, au.UserId });

            modelBuilder.Entity<User>()
                .HasMany(u => u.AgendaUsers)
                .WithOne(au => au.User)
                .HasForeignKey(au => au.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Agenda>()
                .HasMany(a => a.AgendaUsers)
                .WithOne(au => au.Agenda)
                .HasForeignKey(au => au.AgendaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Agenda>()
                .HasMany(a => a.Todos)
                .WithOne(t => t.Agenda)
                .HasForeignKey(t => t.AgendaId)
                .OnDelete(DeleteBehavior.Cascade);

            //base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
