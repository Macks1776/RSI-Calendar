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

            // EMPLOYEE SEED DATA
            builder.Entity<Employee>().HasData(
                new Employee
                {
                    ID = 1,
                    FName = "Larry",
                    LName = "Overholt",
                    Branch = "Augusta",
                    Role = "Admin",
                    Email = "loverhol@smartweb.augustatech.edu",
                    Password = "LarryOverholt2021"
                },

                new Employee
                {
                    ID = 2,
                    FName = "Max",
                    LName = "Swann",
                    Branch = "Augusta",
                    Role = "Employee",
                    Email = "maxswann1995@gmail.com",
                    Password = "MaxSwann2021"
                },

                new Employee
                {
                    ID = 3,
                    FName = "Keyla",
                    LName = "Washington",
                    Branch = "Augusta",
                    Role = "CultrualAmbassador",
                    Email = "khobbswa@smartweb.augustatech.edu",
                    Password = "KeylaWashington2021"
                },

                new Employee
                {
                    ID = 4,
                    FName = "Matthew",
                    LName = "Jeffreys",
                    Branch = "Augusta",
                    Role = "CultrualAmbassador",
                    Email = "mcjeffreys7@gmail.com",
                    Password = "MatthewJeffreys2021"
                }
                );

            // EVENT SEED DATA
            builder.Entity<Event>().HasData(
                new Event
                {
                    EventID = 1,
                    Name = "Sample Event",
                    Type = "Req",
                    Branch = "Augusta, GA",
                    Description = "Sample Description",
                    StartDate = DateTime.Parse("10/13/2021 2:00:00 PM"),
                    EndDate = DateTime.Parse("10/13/2021 2:30:00 PM")
                },

                new Event
                {
                    EventID = 2,
                    Name = "NLCS Game 2",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "A bunch of employees are meeting at the front gate at Truist Park. Hope you can join us!",
                    StartDate = DateTime.Parse("10/19/2021 8:08:00 PM"),
                    EndDate = DateTime.Parse("10/19/2021 11:08:00 PM")
                },

                new Event
                {
                    EventID = 3,
                    Name = "Cookout",
                    Type = "Fam",
                    Branch = "Augusta, GA",
                    Description = "We're having a good old fashioned cookout so feel free to bring the whole family!",
                    StartDate = DateTime.Parse("10/23/2021 7:00:00 PM"),
                    EndDate = DateTime.Parse("10/23/2021 9:00:00 PM")
                },

                new Event
                {
                    EventID = 4,
                    Name = ".NET 5: Whats New?!",
                    Type = "Edu",
                    Branch = "Augusta, GA",
                    Description = "Tech Tuesday training on what's new in .NET 5.",
                    StartDate = DateTime.Parse("10/26/2021 9:00:00 AM"),
                    EndDate = DateTime.Parse("10/26/2021 9:30:00 AM")
                },

                new Event
                {
                    EventID = 5,
                    Name = "Costume Day!",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "Wear your best costume!",
                    StartDate = DateTime.Parse("10/30/2021 8:00:00 AM"),
                    EndDate = DateTime.Parse("10/30/2021 5:00:00 PM")
                }
                );

            // ATTACHEMENT SEED DATA
            builder.Entity<Attachment>().HasData(
                new Attachment
                {
                    ID = 1,
                    EventID = 1,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 2,
                    EventID = 1,
                    Title = "NFL",
                    Link = "https://nfl.com"
                },

                new Attachment
                {
                    ID = 3,
                    EventID = 2,
                    Title = "Game Preview",
                    Link = "https://tomahawktake.com/2021/10/17/atlanta-braves-vs-dodgers-nlcs-game-2-lineup-odds-prediction-pick-watch/"
                },

                new Attachment
                {
                    ID = 4,
                    EventID = 2,
                    Title = "Game Highlights",
                    Link = "https://youtu.be/ZxZOz5C1BbE"
                },

                new Attachment
                {
                    ID = 5,
                    EventID = 4,
                    Title = "IAmTimCorey - Big Changes in .NET 5, C# 9, and Visual Studio 2019 (v16.8)",
                    Link = "https://youtu.be/zjVgQNfAEOs"
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
