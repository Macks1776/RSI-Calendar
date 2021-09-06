using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSI_Calendar.Models
{
    public class CalendarContext : IdentityDbContext<User>
    {
        public CalendarContext(DbContextOptions<CalendarContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Attachment>().HasKey(x => x.ID);

            builder.Entity<Employee>().HasData(
                new Employee
                {
                    ID = 1,
                    FName = "Larry",
                    LName = "Overholt",
                    Location = "Augusta",
                    Role = "Admin",
                    Email = "loverhol@smartweb.augustatech.edu",
                    Password = "LarryOverholt2021"
                },

                new Employee
                {
                    ID = 2,
                    FName = "Max",
                    LName = "Swann",
                    Location = "Augusta",
                    Role = "Employee",
                    Email = "maxswann1995@gmail.com",
                    Password = "MaxSwann2021"
                },

                new Employee
                {
                    ID = 3,
                    FName = "Keyla",
                    LName = "Washington",
                    Location = "Augusta",
                    Role = "CultrualAmbassador",
                    Email = "khobbswa@smartweb.augustatech.edu",
                    Password = "KeylaWashington2021"
                },

                new Employee
                {
                    ID = 4,
                    FName = "Matthew",
                    LName = "Jeffreys",
                    Location = "Augusta",
                    Role = "CultrualAmbassador",
                    Email = "mcjeffreys7@gmail.com",
                    Password = "MatthewJeffreys2021"
                }
                );

            builder.Entity<Event>().HasData(
                new Event
                {
                    EventID = 1,
                    Name = "Sample Event",
                    Type = "Optional",
                    Location = "Augusta Tech",
                    Date = "September 9, 2021",
                    Time = "6:50 PM"
                }
                );

            builder.Entity<Attachment>().HasData(
                new Attachment
                {
                    ID = 1,
                    EventID = 1,
                    Link = "www.samplelink.com"
                },

                new Attachment
                {
                    ID = 101,
                    EventID = 1,
                    Link = "www.samplelink.com/another"
                }
                );
        }
    }
}
