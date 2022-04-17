using Data.Entities;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<TreatmentDetail> TreatmentDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Email = "email1@email.com",
                    Firstname = "NGuyen Van A",
                    Role = "User",
                    UId = "AVASASSAS"
                },
                new User()
                {
                    Email = "email2@email.com",
                    Firstname = "NGuyen Van B",
                    Role = "User",
                    UId = "AVASASSAS1"
                }, new User()
                {
                    Email = "email3@email.com",
                    Firstname = "NGuyen Van C",
                    Role = "User",
                    UId = "AVASASSAS2"
                }
                );
        }

    }
}
