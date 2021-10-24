﻿using System;
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
                    EventID = 2,
                    Name = "NLCS Game 2",
                    Type = "Fun",
                    Location = "Augusta, GA",
                    Description = "A bunch of employees are meeting at the front gate at Truist Park. Hope you can join us!",
                    StartDate = DateTime.Parse("10/19/2021 8:08:00 PM"),
                    EndDate = DateTime.Parse("10/19/2021 11:08:00 PM")
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

        public static async Task CreateMasterUser(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string username = "Master";
            string password = "RSIteam2021";
            string roleOne = "Admin";
            string roleTwo = "CulAm";

            //if roles don't exist, create them
            if (await roleManager.FindByNameAsync(roleOne) == null)
                await roleManager.CreateAsync(new IdentityRole(roleOne));

            if (await roleManager.FindByNameAsync(roleTwo) == null)
                await roleManager.CreateAsync(new IdentityRole(roleTwo));

            //if username doesn't exist, create it and add to role
            if(await userManager.FindByNameAsync(username) == null)
            {
                User user = new User { UserName = username };
                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleOne);
                    await userManager.AddToRoleAsync(user, roleTwo);
                }
            }
        }
    }
}
