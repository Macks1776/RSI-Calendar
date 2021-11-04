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
                    Branch = "Augusta, GA",
                    Role = "Admin",
                    Email = "loverhol@smartweb.augustatech.edu",
                    Password = "LarryOverholt2021"
                },

                new Employee
                {
                    ID = 2,
                    FName = "Max",
                    LName = "Swann",
                    Branch = "Augusta, GA",
                    Role = "Employee",
                    Email = "maxswann1995@gmail.com",
                    Password = "MaxSwann2021"
                },

                new Employee
                {
                    ID = 3,
                    FName = "Keyla",
                    LName = "Washington",
                    Branch = "Augusta, GA",
                    Role = "CultrualAmbassador",
                    Email = "khobbswa@smartweb.augustatech.edu",
                    Password = "KeylaWashington2021"
                },

                new Employee
                {
                    ID = 4,
                    FName = "Matthew",
                    LName = "Jeffreys",
                    Branch = "Augusta, GA",
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
                    Location = "1234 Sample St, Sampleton, GA 12345",
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
                    Location = "755 Battery Ave SE, Atlanta, GA 30339",
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
                    Location = "3012 Peach Orchard Rd, Augusta, GA 30906",
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
                    Location = "The Alan Turing room",
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
                    Location = "1450 Greene St #200, Augusta, GA 30901",
                    StartDate = DateTime.Parse("11/30/2021 1:00:00 PM"),
                    EndDate = DateTime.Parse("11/30/2021 4:30:00 PM")
                },

                new Event
                {
                    EventID = 6,
                    Name = "Sample Event",
                    Type = "Req",
                    Branch = "Augusta, GA",
                    Description = "Sample Description",
                    Location = "1234 Sample St, Sampleton, GA 12345",
                    StartDate = DateTime.Parse("11/13/2021 2:00:00 PM"),
                    EndDate = DateTime.Parse("11/13/2021 2:30:00 PM")
                },

                new Event
                {
                    EventID = 7,
                    Name = "NLCS Game 2",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "A bunch of employees are meeting at the front gate at Truist Park. Hope you can join us!",
                    Location = "755 Battery Ave SE, Atlanta, GA 30339",
                    StartDate = DateTime.Parse("11/19/2021 8:08:00 PM"),
                    EndDate = DateTime.Parse("11/19/2021 11:08:00 PM")
                },

                new Event
                {
                    EventID = 8,
                    Name = "Cookout",
                    Type = "Fam",
                    Branch = "Augusta, GA",
                    Description = "We're having a good old fashioned cookout so feel free to bring the whole family!",
                    Location = "3012 Peach Orchard Rd, Augusta, GA 30906",
                    StartDate = DateTime.Parse("11/23/2021 7:00:00 PM"),
                    EndDate = DateTime.Parse("11/23/2021 9:00:00 PM")
                },

                new Event
                {
                    EventID = 9,
                    Name = ".NET 5: Whats New?!",
                    Type = "Edu",
                    Branch = "Augusta, GA",
                    Description = "Tech Tuesday training on what's new in .NET 5.",
                    Location = "The Alan Turing room",
                    StartDate = DateTime.Parse("11/26/2021 9:00:00 AM"),
                    EndDate = DateTime.Parse("11/26/2021 9:30:00 AM")
                },

                new Event
                {
                    EventID = 10,
                    Name = "Costume Day!",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "Wear your best costume!",
                    Location = "1450 Greene St #200, Augusta, GA 30901",
                    StartDate = DateTime.Parse("11/30/2021 1:00:00 PM"),
                    EndDate = DateTime.Parse("11/30/2021 4:30:00 PM")
                },

                new Event
                {
                    EventID = 11,
                    Name = "Sample 1",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "Lorem ipsom dolar",
                    Location = "Second door on the right",
                    StartDate = DateTime.Parse("11/01/2021 1:00:00 PM"),
                    EndDate = DateTime.Parse("11/01/2021 4:30:00 PM")
                },

                new Event
                {
                    EventID = 12,
                    Name = "Sample 2",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "Lorem ipsom dolar",
                    Location = "Second door on the right",
                    StartDate = DateTime.Parse("11/02/2021 1:00:00 PM"),
                    EndDate = DateTime.Parse("11/02/2021 4:30:00 PM")
                },

                new Event
                {
                    EventID = 13,
                    Name = "Sample 3",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "Lorem ipsom dolar",
                    Location = "Second door on the right",
                    StartDate = DateTime.Parse("11/03/2021 1:00:00 PM"),
                    EndDate = DateTime.Parse("11/04/2021 4:30:00 PM")
                },

                new Event
                {
                    EventID = 14,
                    Name = "Sample 4",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "Lorem ipsom dolar",
                    Location = "Second door on the right",
                    StartDate = DateTime.Parse("11/04/2021 1:00:00 PM"),
                    EndDate = DateTime.Parse("11/04/2021 4:30:00 PM")
                },

                new Event
                {
                    EventID = 15,
                    Name = "Sample 5",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "Lorem ipsom dolar",
                    Location = "Second door on the right",
                    StartDate = DateTime.Parse("11/05/2021 1:00:00 PM"),
                    EndDate = DateTime.Parse("11/05/2021 4:30:00 PM")
                },

                new Event
                {
                    EventID = 16,
                    Name = "Sample 6",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "Lorem ipsom dolar",
                    Location = "Second door on the right",
                    StartDate = DateTime.Parse("11/06/2021 1:00:00 PM"),
                    EndDate = DateTime.Parse("11/07/2021 4:30:00 PM")
                },

                new Event
                {
                    EventID = 17,
                    Name = "Sample 7",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "Lorem ipsom dolar",
                    Location = "Second door on the right",
                    StartDate = DateTime.Parse("11/07/2021 1:00:00 PM"),
                    EndDate = DateTime.Parse("11/07/2021 4:30:00 PM")
                },

                new Event
                {
                    EventID = 18,
                    Name = "Sample 8",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "Lorem ipsom dolar",
                    Location = "Second door on the right",
                    StartDate = DateTime.Parse("11/18/2021 1:00:00 PM"),
                    EndDate = DateTime.Parse("11/18/2021 4:30:00 PM")
                },

                new Event
                {
                    EventID = 19,
                    Name = "Thanksgiving",
                    Type = "Fam",
                    Branch = "Augusta, GA",
                    Description = "Tell your family and friends how thankful for them that you are!",
                    Location = "Home",
                    StartDate = DateTime.Parse("11/25/2021 12:00:00 AM"),
                    EndDate = DateTime.Parse("11/26/2021 12:00:00 AM")
                },

                new Event
                {
                    EventID = 20,
                    Name = "Sample 1",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "Lorem ipsom dolar",
                    Location = "Second door on the right",
                    StartDate = DateTime.Parse("12/01/2021 1:00:00 PM"),
                    EndDate = DateTime.Parse("12/01/2021 4:30:00 PM")
                },

                new Event
                {
                    EventID = 21,
                    Name = "Sample 2",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "Lorem ipsom dolar",
                    Location = "Second door on the right",
                    StartDate = DateTime.Parse("12/02/2021 1:00:00 PM"),
                    EndDate = DateTime.Parse("12/02/2021 4:30:00 PM")
                },

                new Event
                {
                    EventID = 22,
                    Name = "Sample 3",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "Lorem ipsom dolar",
                    Location = "Second door on the right",
                    StartDate = DateTime.Parse("12/03/2021 1:00:00 PM"),
                    EndDate = DateTime.Parse("12/04/2021 4:30:00 PM")
                },

                new Event
                {
                    EventID = 23,
                    Name = "Sample 4",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "Lorem ipsom dolar",
                    Location = "Second door on the right",
                    StartDate = DateTime.Parse("12/04/2021 1:00:00 PM"),
                    EndDate = DateTime.Parse("12/04/2021 4:30:00 PM")
                },

                new Event
                {
                    EventID = 24,
                    Name = "Sample 5",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "Lorem ipsom dolar",
                    Location = "Second door on the right",
                    StartDate = DateTime.Parse("12/05/2021 1:00:00 PM"),
                    EndDate = DateTime.Parse("12/05/2021 4:30:00 PM")
                },

                new Event
                {
                    EventID = 25,
                    Name = "Sample 6",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "Lorem ipsom dolar",
                    Location = "Second door on the right",
                    StartDate = DateTime.Parse("12/06/2021 1:00:00 PM"),
                    EndDate = DateTime.Parse("12/07/2021 4:30:00 PM")
                },

                new Event
                {
                    EventID = 26,
                    Name = "Sample 7",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "Lorem ipsom dolar",
                    Location = "Second door on the right",
                    StartDate = DateTime.Parse("12/07/2021 1:00:00 PM"),
                    EndDate = DateTime.Parse("12/07/2021 4:30:00 PM")
                },

                new Event
                {
                    EventID = 27,
                    Name = "Sample 8",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "Lorem ipsom dolar",
                    Location = "Second door on the right",
                    StartDate = DateTime.Parse("12/18/2021 1:00:00 PM"),
                    EndDate = DateTime.Parse("12/18/2021 4:30:00 PM")
                },

                new Event
                {
                    EventID = 28,
                    Name = "Sample 9",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "Lorem ipsom dolar",
                    Location = "Second door on the right",
                    StartDate = DateTime.Parse("12/29/2021 1:00:00 PM"),
                    EndDate = DateTime.Parse("12/30/2021 4:30:00 PM")
                },

                new Event
                {
                    EventID = 29,
                    Name = "Christmas Eve",
                    Type = "Fam",
                    Branch = "Augusta, GA",
                    Description = "Merry Christmas Eve!",
                    Location = "Home",
                    StartDate = DateTime.Parse("12/24/2021 12:00:00 AM"),
                    EndDate = DateTime.Parse("12/25/2021 12:00:00 AM")
                },

                new Event
                {
                    EventID = 30,
                    Name = "Christmas Day",
                    Type = "Fam",
                    Branch = "Augusta, GA",
                    Description = "Merry Christmas Everyone!",
                    Location = "Home",
                    StartDate = DateTime.Parse("12/25/2021 12:00:00 AM"),
                    EndDate = DateTime.Parse("12/26/2021 12:00:00 AM")
                }
                );

            // ATTACHMENT SEED DATA
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
                },

                new Attachment
                {
                    ID = 6,
                    EventID = 6,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 7,
                    EventID = 7,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 8,
                    EventID = 8,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 9,
                    EventID = 9,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 10,
                    EventID = 10,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 11,
                    EventID = 11,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 12,
                    EventID = 12,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 13,
                    EventID = 13,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 14,
                    EventID = 14,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 15,
                    EventID = 15,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 16,
                    EventID = 16,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 17,
                    EventID = 17,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 18,
                    EventID = 18,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 19,
                    EventID = 19,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 20,
                    EventID = 20,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 21,
                    EventID = 21,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 22,
                    EventID = 22,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 23,
                    EventID = 23,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 24,
                    EventID = 24,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 25,
                    EventID = 25,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 26,
                    EventID = 26,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 27,
                    EventID = 27,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 28,
                    EventID = 28,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 29,
                    EventID = 29,
                    Title = "Google",
                    Link = "https://google.com"
                },

                new Attachment
                {
                    ID = 30,
                    EventID = 30,
                    Title = "Google",
                    Link = "https://google.com"
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
