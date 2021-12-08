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

            // EVENT SEED DATA
            builder.Entity<Event>().HasData(
                new Event
                {
                    EventID = 1,
                    Name = "The Basics of SAP Data Services by Sam Gassem",
                    Type = "Req",
                    Branch = "Augusta, GA",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1863 Gettysburg, PA",
                    StartDate = DateTime.Parse("11/01/2021 8:00:00 AM"),
                    EndDate = DateTime.Parse("11/01/2021 8:30:00 AM"),
                },

                new Event
                {
                    EventID = 2,
                    Name = "Movie Night",
                    Type = "Fun",
                    Branch = "Albuquerque, NM",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1776 Freedom Street",
                    StartDate = DateTime.Parse("11/02/2021 7:00:00 PM"),
                    EndDate = DateTime.Parse("11/02/2021 9:30:00 PM"),
                },

                new Event
                {
                    EventID = 3,
                    Name = "Cookout",
                    Type = "Fam",
                    Branch = "FortWayne, IN",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "3570 Crispus Attucks Way",
                    StartDate = DateTime.Parse("11/03/2021 10:30:00 AM"),
                    EndDate = DateTime.Parse("11/03/2021 11:00:00 AM"),
                },

                new Event
                {
                    EventID = 4,
                    Name = "Lecture - .NET 5: Whats New?!",
                    Type = "Edu",
                    Branch = "Augusta, GA",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "7476 Hancock Ave",
                    StartDate = DateTime.Parse("11/04/2021 11:30:00 AM"),
                    EndDate = DateTime.Parse("11/04/2021 12:00:00 PM"),
                },

                new Event
                {
                    EventID = 5,
                    Name = "Sprint Retrospective",
                    Type = "Req",
                    Branch = "Jonesboro, AR",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207",
                    StartDate = DateTime.Parse("11/05/2021 12:30:00 PM"),
                    EndDate = DateTime.Parse("11/05/2021 01:00:00 PM"),
                },

                new Event
                {
                    EventID = 6,
                    Name = "Trivia Night",
                    Type = "Fun",
                    Branch = "Madison, WI",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1863 Gettysburg, PA",
                    StartDate = DateTime.Parse("11/06/2021 07:30:00 PM"),
                    EndDate = DateTime.Parse("11/06/2021 09:30:00 PM"),
                },

                new Event
                {
                    EventID = 7,
                    Name = "Toy Drive",
                    Type = "Fam",
                    Branch = "Milwaukee, WI",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1776 Freedom Street",
                    StartDate = DateTime.Parse("11/08/2021 12:00:00 AM"),
                    EndDate = DateTime.Parse("11/12/2021 11:59:00 PM"),
                },

                new Event
                {
                    EventID = 8,
                    Name = "Lecture - Whats new in Visual Studio 2021?",
                    Type = "Edu",
                    Branch = "Mobile, AL",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "3570 Crispus Attucks Way",
                    StartDate = DateTime.Parse("11/08/2021 04:00:00 PM"),
                    EndDate = DateTime.Parse("11/08/2021 04:30:00 PM"),
                },

                new Event
                {
                    EventID = 9,
                    Name = "Backlog Refinement",
                    Type = "Req",
                    Branch = "Oklahoma City, OK",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "7476 Hancock Ave",
                    StartDate = DateTime.Parse("11/09/2021 8:00:00 AM"),
                    EndDate = DateTime.Parse("11/09/2021 8:30:00 AM"),
                },

                new Event
                {
                    EventID = 10,
                    Name = "Costume Day!",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207",
                    StartDate = DateTime.Parse("11/10/2021 9:00:00 AM"),
                    EndDate = DateTime.Parse("11/10/2021 9:30:00 AM"),
                },

                new Event
                {
                    EventID = 11,
                    Name = "Veterans Day Cookout",
                    Type = "Fam",
                    Branch = "Albuquerque, NM",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1863 Gettysburg, PA",
                    StartDate = DateTime.Parse("11/11/2021 10:30:00 AM"),
                    EndDate = DateTime.Parse("11/11/2021 11:00:00 AM"),
                },

                new Event
                {
                    EventID = 12,
                    Name = "Lecture - Backlog Refinement",
                    Type = "Edu",
                    Branch = "FortWayne, IN",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1776 Freedom Street",
                    StartDate = DateTime.Parse("11/12/2021 11:30:00 AM"),
                    EndDate = DateTime.Parse("11/12/2021 12:00:00 PM"),
                },

                new Event
                {
                    EventID = 13,
                    Name = "Code Review",
                    Type = "Req",
                    Branch = "Augusta, GA",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "3570 Crispus Attucks Way",
                    StartDate = DateTime.Parse("11/12/2021 12:30:00 PM"),
                    EndDate = DateTime.Parse("11/12/2021 01:00:00 PM"),
                },

                new Event
                {
                    EventID = 14,
                    Name = "Meetup at the Baseball Game",
                    Type = "Fun",
                    Branch = "Jonesboro, AR",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "7476 Hancock Ave",
                    StartDate = DateTime.Parse("11/14/2021 06:30:00 PM"),
                    EndDate = DateTime.Parse("11/14/2021 08:30:00 PM"),
                },

                new Event
                {
                    EventID = 15,
                    Name = "Picnic in the Park",
                    Type = "Fam",
                    Branch = "Madison, WI",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207",
                    StartDate = DateTime.Parse("11/15/2021 12:00:00 PM"),
                    EndDate = DateTime.Parse("11/15/2021 01:30:00 PM"),
                },

                new Event
                {
                    EventID = 16,
                    Name = "Lecture - Ways to Improve Code Reviews",
                    Type = "Edu",
                    Branch = "Milwaukee, WI",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1863 Gettysburg, PA",
                    StartDate = DateTime.Parse("11/16/2021 04:00:00 PM"),
                    EndDate = DateTime.Parse("11/16/2021 04:30:00 PM"),
                },

                new Event
                {
                    EventID = 17,
                    Name = "Sprint Planning",
                    Type = "Req",
                    Branch = "Mobile, AL",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1776 Freedom Street",
                    StartDate = DateTime.Parse("11/17/2021 8:00:00 AM"),
                    EndDate = DateTime.Parse("11/17/2021 8:30:00 AM"),
                },

                new Event
                {
                    EventID = 18,
                    Name = "Game Night",
                    Type = "Fun",
                    Branch = "Oklahoma City, OK",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "3570 Crispus Attucks Way",
                    StartDate = DateTime.Parse("11/18/2021 8:00:00 PM"),
                    EndDate = DateTime.Parse("11/18/2021 9:30:00 PM"),
                },

                new Event
                {
                    EventID = 19,
                    Name = "Cookout",
                    Type = "Fam",
                    Branch = "Augusta, GA",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "7476 Hancock Ave",
                    StartDate = DateTime.Parse("11/19/2021 10:30:00 AM"),
                    EndDate = DateTime.Parse("11/19/2021 12:00:00 PM"),
                },

                new Event
                {
                    EventID = 20,
                    Name = "Lecture - Improving your communication skills as a developer",
                    Type = "Edu",
                    Branch = "Albuquerque, NM",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207",
                    StartDate = DateTime.Parse("11/19/2021 11:30:00 AM"),
                    EndDate = DateTime.Parse("11/19/2021 12:00:00 PM"),
                },

                new Event
                {
                    EventID = 21,
                    Name = "The Basics of SAP Data Services by Sam Gassem",
                    Type = "Req",
                    Branch = "FortWayne, IN",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1863 Gettysburg, PA",
                    StartDate = DateTime.Parse("11/22/2021 12:30:00 PM"),
                    EndDate = DateTime.Parse("11/22/2021 01:00:00 PM"),
                },

                new Event
                {
                    EventID = 22,
                    Name = "Paint Night",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1776 Freedom Street",
                    StartDate = DateTime.Parse("11/22/2021 01:30:00 PM"),
                    EndDate = DateTime.Parse("11/22/2021 02:30:00 PM"),
                },

                new Event
                {
                    EventID = 23,
                    Name = "Toy Drive",
                    Type = "Fam",
                    Branch = "Jonesboro, AR",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "3570 Crispus Attucks Way",
                    StartDate = DateTime.Parse("11/22/2021 12:00:00 AM"),
                    EndDate = DateTime.Parse("11/26/2021 05:00:00 PM"),
                },

                new Event
                {
                    EventID = 24,
                    Name = "Lecture - .NET 5: Whats New?!",
                    Type = "Edu",
                    Branch = "Madison, WI",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "7476 Hancock Ave",
                    StartDate = DateTime.Parse("11/24/2021 04:00:00 PM"),
                    EndDate = DateTime.Parse("11/24/2021 04:30:00 PM"),
                },

                new Event
                {
                    EventID = 25,
                    Name = "Sprint Retrospective",
                    Type = "Req",
                    Branch = "Milwaukee, WI",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207",
                    StartDate = DateTime.Parse("11/24/2021 8:00:00 AM"),
                    EndDate = DateTime.Parse("11/24/2021 8:30:00 AM"),
                },

                new Event
                {
                    EventID = 26,
                    Name = "Company Softball Game",
                    Type = "Fun",
                    Branch = "Mobile, AL",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1863 Gettysburg, PA",
                    StartDate = DateTime.Parse("11/26/2021 5:00:00 PM"),
                    EndDate = DateTime.Parse("11/26/2021 6:30:00 PM"),
                },

                new Event
                {
                    EventID = 27,
                    Name = "Food Drive",
                    Type = "Fam",
                    Branch = "Oklahoma City, OK",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1776 Freedom Street",
                    StartDate = DateTime.Parse("11/29/2021 08:30:00 AM"),
                    EndDate = DateTime.Parse("12/03/2021 07:00:00 PM"),
                },

                new Event
                {
                    EventID = 28,
                    Name = "Lecture - Whats new in Visual Studio 2021?",
                    Type = "Edu",
                    Branch = "Augusta, GA",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "3570 Crispus Attucks Way",
                    StartDate = DateTime.Parse("11/29/2021 11:30:00 AM"),
                    EndDate = DateTime.Parse("11/29/2021 12:00:00 PM"),
                },

                new Event
                {
                    EventID = 29,
                    Name = "Backlog Refinement",
                    Type = "Req",
                    Branch = "Albuquerque, NM",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "7476 Hancock Ave",
                    StartDate = DateTime.Parse("11/29/2021 12:30:00 PM"),
                    EndDate = DateTime.Parse("11/29/2021 01:00:00 PM"),
                },

                new Event
                {
                    EventID = 30,
                    Name = "Movie Night",
                    Type = "Fun",
                    Branch = "FortWayne, IN",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207",
                    StartDate = DateTime.Parse("11/30/2021 06:30:00 PM"),
                    EndDate = DateTime.Parse("11/30/2021 08:30:00 PM"),
                },

                new Event
                {
                    EventID = 31,
                    Name = "Picnic in the Park",
                    Type = "Fam",
                    Branch = "Augusta, GA",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1863 Gettysburg, PA",
                    StartDate = DateTime.Parse("12/01/2021 11:00:00 AM"),
                    EndDate = DateTime.Parse("12/01/2021 12:30:00 PM"),
                },

                new Event
                {
                    EventID = 32,
                    Name = "Lecture - Backlog Refinement",
                    Type = "Edu",
                    Branch = "Jonesboro, AR",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1776 Freedom Street",
                    StartDate = DateTime.Parse("12/02/2021 04:00:00 PM"),
                    EndDate = DateTime.Parse("12/02/2021 04:30:00 PM"),
                },

                new Event
                {
                    EventID = 33,
                    Name = "Code Review",
                    Type = "Req",
                    Branch = "Madison, WI",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "3570 Crispus Attucks Way",
                    StartDate = DateTime.Parse("12/03/2021 8:00:00 AM"),
                    EndDate = DateTime.Parse("12/03/2021 8:30:00 AM"),
                },

                new Event
                {
                    EventID = 34,
                    Name = "Trivia Night",
                    Type = "Fun",
                    Branch = "Milwaukee, WI",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "7476 Hancock Ave",
                    StartDate = DateTime.Parse("12/04/2021 8:00:00 PM"),
                    EndDate = DateTime.Parse("12/04/2021 9:30:00 PM"),
                },

                new Event
                {
                    EventID = 35,
                    Name = "Cookout",
                    Type = "Fam",
                    Branch = "Mobile, AL",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207",
                    StartDate = DateTime.Parse("12/05/2021 10:30:00 AM"),
                    EndDate = DateTime.Parse("12/05/2021 12:00:00 PM"),
                },

                new Event
                {
                    EventID = 36,
                    Name = "Lecture - Ways to Improve Code Reviews",
                    Type = "Edu",
                    Branch = "Oklahoma City, OK",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1863 Gettysburg, PA",
                    StartDate = DateTime.Parse("12/06/2021 11:30:00 AM"),
                    EndDate = DateTime.Parse("12/06/2021 12:00:00 PM"),
                },

                new Event
                {
                    EventID = 37,
                    Name = "Sprint Planning",
                    Type = "Req",
                    Branch = "Augusta, GA",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1776 Freedom Street",
                    StartDate = DateTime.Parse("12/07/2021 12:30:00 PM"),
                    EndDate = DateTime.Parse("12/07/2021 01:00:00 PM"),
                },

                new Event
                {
                    EventID = 38,
                    Name = "Costume Day!",
                    Type = "Fun",
                    Branch = "Albuquerque, NM",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "3570 Crispus Attucks Way",
                    StartDate = DateTime.Parse("12/08/2021 08:00:00 AM"),
                    EndDate = DateTime.Parse("12/08/2021 05:00:00 PM"),
                },

                new Event
                {
                    EventID = 39,
                    Name = "Toy Drive",
                    Type = "Fam",
                    Branch = "FortWayne, IN",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "7476 Hancock Ave",
                    StartDate = DateTime.Parse("12/06/2021 08:00:00 AM"),
                    EndDate = DateTime.Parse("12/10/2021 05:00:00 PM"),
                },

                new Event
                {
                    EventID = 40,
                    Name = "Lecture - Improving your communication skills as a developer",
                    Type = "Edu",
                    Branch = "Augusta, GA",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207",
                    StartDate = DateTime.Parse("12/10/2021 04:00:00 PM"),
                    EndDate = DateTime.Parse("12/10/2021 04:30:00 PM"),
                },

                new Event
                {
                    EventID = 41,
                    Name = "The Basics of SAP Data Services by Sam Gassem",
                    Type = "Req",
                    Branch = "Jonesboro, AR",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1863 Gettysburg, PA",
                    StartDate = DateTime.Parse("12/10/2021 8:00:00 AM"),
                    EndDate = DateTime.Parse("12/10/2021 8:30:00 AM"),
                },

                new Event
                {
                    EventID = 42,
                    Name = "Meetup at the Baseball Game",
                    Type = "Fun",
                    Branch = "Madison, WI",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1776 Freedom Street",
                    StartDate = DateTime.Parse("12/12/2021 7:00:00 PM"),
                    EndDate = DateTime.Parse("12/12/2021 9:30:00 PM"),
                },

                new Event
                {
                    EventID = 43,
                    Name = "Food Drive",
                    Type = "Fam",
                    Branch = "Milwaukee, WI",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "3570 Crispus Attucks Way",
                    StartDate = DateTime.Parse("12/13/2021 10:30:00 AM"),
                    EndDate = DateTime.Parse("12/17/2021 05:00:00 PM"),
                },

                new Event
                {
                    EventID = 44,
                    Name = "Lecture - .NET 5: Whats New?!",
                    Type = "Edu",
                    Branch = "Mobile, AL",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "7476 Hancock Ave",
                    StartDate = DateTime.Parse("12/14/2021 11:30:00 AM"),
                    EndDate = DateTime.Parse("12/14/2021 12:00:00 PM"),
                },

                new Event
                {
                    EventID = 45,
                    Name = "Sprint Retrospective",
                    Type = "Req",
                    Branch = "Oklahoma City, OK",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207",
                    StartDate = DateTime.Parse("12/15/2021 12:30:00 PM"),
                    EndDate = DateTime.Parse("12/15/2021 01:00:00 PM"),
                },

                new Event
                {
                    EventID = 46,
                    Name = "Game Night",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1863 Gettysburg, PA",
                    StartDate = DateTime.Parse("12/16/2021 07:30:00 PM"),
                    EndDate = DateTime.Parse("12/16/2021 09:30:00 PM"),
                },

                new Event
                {
                    EventID = 47,
                    Name = "Picnic in the Park",
                    Type = "Fam",
                    Branch = "Albuquerque, NM",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1776 Freedom Street",
                    StartDate = DateTime.Parse("12/17/2021 11:00:00 AM"),
                    EndDate = DateTime.Parse("12/17/2021 01:30:00 PM"),
                },

                new Event
                {
                    EventID = 48,
                    Name = "Lecture - Whats new in Visual Studio 2021?",
                    Type = "Edu",
                    Branch = "FortWayne, IN",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "3570 Crispus Attucks Way",
                    StartDate = DateTime.Parse("12/17/2021 04:00:00 PM"),
                    EndDate = DateTime.Parse("12/17/2021 04:30:00 PM"),
                },

                new Event
                {
                    EventID = 49,
                    Name = "Backlog Refinement",
                    Type = "Req",
                    Branch = "Augusta, GA",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "7476 Hancock Ave",
                    StartDate = DateTime.Parse("12/20/2021 8:00:00 AM"),
                    EndDate = DateTime.Parse("12/20/2021 8:30:00 AM"),
                },

                new Event
                {
                    EventID = 50,
                    Name = "Paint Night",
                    Type = "Fun",
                    Branch = "Jonesboro, AR",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207",
                    StartDate = DateTime.Parse("12/20/2021 7:00:00 PM"),
                    EndDate = DateTime.Parse("12/20/2021 9:30:00 PM"),
                },

                new Event
                {
                    EventID = 51,
                    Name = "Snowball Fight and Cookout",
                    Type = "Fam",
                    Branch = "Madison, WI",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1863 Gettysburg, PA",
                    StartDate = DateTime.Parse("12/21/2021 10:30:00 AM"),
                    EndDate = DateTime.Parse("12/21/2021 02:00:00 PM"),
                },

                new Event
                {
                    EventID = 52,
                    Name = "Lecture - Backlog Refinement",
                    Type = "Edu",
                    Branch = "Milwaukee, WI",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1776 Freedom Street",
                    StartDate = DateTime.Parse("12/22/2021 11:30:00 AM"),
                    EndDate = DateTime.Parse("12/22/2021 12:00:00 PM"),
                },

                new Event
                {
                    EventID = 53,
                    Name = "Code Review",
                    Type = "Req",
                    Branch = "Mobile, AL",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "3570 Crispus Attucks Way",
                    StartDate = DateTime.Parse("12/23/2021 12:30:00 PM"),
                    EndDate = DateTime.Parse("12/23/2021 01:00:00 PM"),
                },

                new Event
                {
                    EventID = 54,
                    Name = "Christmas Eve with Santa!",
                    Type = "Fam",
                    Branch = "Oklahoma City, OK",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "7476 Hancock Ave",
                    StartDate = DateTime.Parse("12/24/2021 02:30:00 PM"),
                    EndDate = DateTime.Parse("12/24/2021 04:30:00 PM"),
                },

                new Event
                {
                    EventID = 55,
                    Name = "Toy Drive",
                    Type = "Fam",
                    Branch = "Augusta, GA",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207",
                    StartDate = DateTime.Parse("12/20/2021 09:00:00 AM"),
                    EndDate = DateTime.Parse("12/24/2021 04:30:00 PM"),
                },

                new Event
                {
                    EventID = 56,
                    Name = "Lecture - Ways to Improve Code Reviews",
                    Type = "Edu",
                    Branch = "Albuquerque, NM",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1863 Gettysburg, PA",
                    StartDate = DateTime.Parse("12/27/2021 04:00:00 PM"),
                    EndDate = DateTime.Parse("12/27/2021 04:30:00 PM"),
                },

                new Event
                {
                    EventID = 57,
                    Name = "Sprint Planning",
                    Type = "Req",
                    Branch = "FortWayne, IN",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1776 Freedom Street",
                    StartDate = DateTime.Parse("12/27/2021 8:00:00 AM"),
                    EndDate = DateTime.Parse("12/27/2021 8:30:00 AM"),
                },

                new Event
                {
                    EventID = 58,
                    Name = "Movie Night",
                    Type = "Fun",
                    Branch = "Augusta, GA",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "3570 Crispus Attucks Way",
                    StartDate = DateTime.Parse("12/28/2021 7:00:00 PM"),
                    EndDate = DateTime.Parse("12/28/2021 9:30:00 PM"),
                },

                new Event
                {
                    EventID = 59,
                    Name = "Food Drive",
                    Type = "Fam",
                    Branch = "Jonesboro, AR",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "7476 Hancock Ave",
                    StartDate = DateTime.Parse("12/27/2021 9:30:00 AM"),
                    EndDate = DateTime.Parse("12/31/2021 4:00:00 PM"),
                },

                new Event
                {
                    EventID = 60,
                    Name = "Lecture - Improving your communication skills as a developer",
                    Type = "Edu",
                    Branch = "Madison, WI",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "Take exit 75, after 1 mile turn right onto Henry Ford Rd and your destination will be on the right at #1207",
                    StartDate = DateTime.Parse("12/30/2021 11:30:00 AM"),
                    EndDate = DateTime.Parse("12/30/2021 12:00:00 PM"),
                },

                new Event
                {
                    EventID = 61,
                    Name = "The Basics of SAP Data Services by Sam Gassem",
                    Type = "Req",
                    Branch = "Milwaukee, WI",
                    Description = "This event will be a lot of fun! Make sure you come ready to enjoy yourself. " +
                      "Bring your own good attitude and be ready to learn and teach! " +
                      "We look forward to seeing you out there!",
                    Location = "1863 Gettysburg, PA",
                    StartDate = DateTime.Parse("12/31/2021 12:30:00 PM"),
                    EndDate = DateTime.Parse("12/31/2021 01:00:00 PM"),
                }
                );

            // ATTACHMENT SEED DATA
            builder.Entity<Attachment>().HasData(

                new Attachment { ID = 1, EventID = 1, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 2, EventID = 2, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 3, EventID = 3, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 4, EventID = 4, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 5, EventID = 5, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 6, EventID = 6, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 7, EventID = 7, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 8, EventID = 8, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 9, EventID = 9, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 10, EventID = 10, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 11, EventID = 11, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 12, EventID = 12, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 13, EventID = 13, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 14, EventID = 14, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 15, EventID = 15, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 16, EventID = 16, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 17, EventID = 17, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 18, EventID = 18, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 19, EventID = 19, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 20, EventID = 20, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 21, EventID = 21, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 22, EventID = 22, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 23, EventID = 23, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 24, EventID = 24, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 25, EventID = 25, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 26, EventID = 26, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 27, EventID = 27, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 28, EventID = 28, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 29, EventID = 29, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 30, EventID = 30, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 31, EventID = 31, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 32, EventID = 32, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 33, EventID = 33, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 34, EventID = 34, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 35, EventID = 35, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 36, EventID = 36, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 37, EventID = 37, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 38, EventID = 38, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 39, EventID = 39, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 40, EventID = 40, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 41, EventID = 41, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 42, EventID = 42, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 43, EventID = 43, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 44, EventID = 44, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 45, EventID = 45, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 46, EventID = 46, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 47, EventID = 47, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 48, EventID = 48, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 49, EventID = 49, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 50, EventID = 50, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 51, EventID = 51, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 52, EventID = 52, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 53, EventID = 53, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 54, EventID = 54, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 55, EventID = 55, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 56, EventID = 56, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 57, EventID = 57, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 58, EventID = 58, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 59, EventID = 59, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 60, EventID = 60, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },
                new Attachment { ID = 61, EventID = 61, Title = "RSI - What We Do", Link = "https://www.ruralsourcing.com/what-we-do/" },

                new Attachment { ID = 62, EventID = 1, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 63, EventID = 2, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 64, EventID = 3, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 65, EventID = 4, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 66, EventID = 5, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 67, EventID = 6, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 68, EventID = 7, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 69, EventID = 8, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 70, EventID = 9, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 71, EventID = 10, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 72, EventID = 11, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 73, EventID = 12, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 74, EventID = 13, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 75, EventID = 14, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 76, EventID = 15, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 77, EventID = 16, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 78, EventID = 17, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 79, EventID = 18, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 80, EventID = 19, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 81, EventID = 20, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 82, EventID = 21, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 83, EventID = 22, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 84, EventID = 23, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 85, EventID = 24, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 86, EventID = 25, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 87, EventID = 26, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 88, EventID = 27, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 89, EventID = 28, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 90, EventID = 29, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 91, EventID = 30, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 92, EventID = 31, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 93, EventID = 32, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 94, EventID = 33, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 95, EventID = 34, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 96, EventID = 35, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 97, EventID = 36, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 98, EventID = 37, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 99, EventID = 38, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 100, EventID = 39, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 101, EventID = 40, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 102, EventID = 41, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 103, EventID = 42, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 104, EventID = 43, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 105, EventID = 44, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 106, EventID = 45, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 107, EventID = 46, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 108, EventID = 47, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 109, EventID = 48, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 110, EventID = 49, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 111, EventID = 50, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 112, EventID = 51, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 113, EventID = 52, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 114, EventID = 53, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 115, EventID = 54, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 116, EventID = 55, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 117, EventID = 56, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 118, EventID = 57, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 119, EventID = 58, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 120, EventID = 59, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 121, EventID = 60, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" },
                new Attachment { ID = 122, EventID = 61, Title = "Augusta Technical College - Computer Programming, Associate of Applied Science Degree", Link = "http://augustatech.smartcatalogiq.com/en/2021/Semester-Catalog/Programs-of-Study/Credit-Program-Schools/School-of-Cyber-and-Design-Media/Computer-Programming-Associate-of-Applied-Science-Degree" }
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
