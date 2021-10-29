﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RSI_Calendar.Models;

namespace RSI_Calendar.Migrations
{
    [DbContext(typeof(CalendarContext))]
    [Migration("20211028204300_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RSI_Calendar.Models.Attachment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventID")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Attachments");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            EventID = 1,
                            Link = "https://google.com",
                            Title = "Google"
                        },
                        new
                        {
                            ID = 2,
                            EventID = 1,
                            Link = "https://nfl.com",
                            Title = "NFL"
                        },
                        new
                        {
                            ID = 3,
                            EventID = 2,
                            Link = "https://tomahawktake.com/2021/10/17/atlanta-braves-vs-dodgers-nlcs-game-2-lineup-odds-prediction-pick-watch/",
                            Title = "Game Preview"
                        },
                        new
                        {
                            ID = 4,
                            EventID = 2,
                            Link = "https://youtu.be/ZxZOz5C1BbE",
                            Title = "Game Highlights"
                        },
                        new
                        {
                            ID = 5,
                            EventID = 4,
                            Link = "https://youtu.be/zjVgQNfAEOs",
                            Title = "IAmTimCorey - Big Changes in .NET 5, C# 9, and Visual Studio 2019 (v16.8)"
                        });
                });

            modelBuilder.Entity("RSI_Calendar.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Branch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Branch = "Augusta, GA",
                            Email = "loverhol@smartweb.augustatech.edu",
                            FName = "Larry",
                            LName = "Overholt",
                            Password = "LarryOverholt2021",
                            Role = "Admin"
                        },
                        new
                        {
                            ID = 2,
                            Branch = "Augusta, GA",
                            Email = "maxswann1995@gmail.com",
                            FName = "Max",
                            LName = "Swann",
                            Password = "MaxSwann2021",
                            Role = "Employee"
                        },
                        new
                        {
                            ID = 3,
                            Branch = "Augusta, GA",
                            Email = "khobbswa@smartweb.augustatech.edu",
                            FName = "Keyla",
                            LName = "Washington",
                            Password = "KeylaWashington2021",
                            Role = "CultrualAmbassador"
                        },
                        new
                        {
                            ID = 4,
                            Branch = "Augusta, GA",
                            Email = "mcjeffreys7@gmail.com",
                            FName = "Matthew",
                            LName = "Jeffreys",
                            Password = "MatthewJeffreys2021",
                            Role = "CultrualAmbassador"
                        });
                });

            modelBuilder.Entity("RSI_Calendar.Models.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Branch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventID");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventID = 1,
                            Branch = "Augusta, GA",
                            Description = "Sample Description",
                            EndDate = new DateTime(2021, 10, 13, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            Location = "1234 Sample St, Sampleton, GA 12345",
                            Name = "Sample Event",
                            StartDate = new DateTime(2021, 10, 13, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Req"
                        },
                        new
                        {
                            EventID = 2,
                            Branch = "Augusta, GA",
                            Description = "A bunch of employees are meeting at the front gate at Truist Park. Hope you can join us!",
                            EndDate = new DateTime(2021, 10, 19, 23, 8, 0, 0, DateTimeKind.Unspecified),
                            Location = "755 Battery Ave SE, Atlanta, GA 30339",
                            Name = "NLCS Game 2",
                            StartDate = new DateTime(2021, 10, 19, 20, 8, 0, 0, DateTimeKind.Unspecified),
                            Type = "Fun"
                        },
                        new
                        {
                            EventID = 3,
                            Branch = "Augusta, GA",
                            Description = "We're having a good old fashioned cookout so feel free to bring the whole family!",
                            EndDate = new DateTime(2021, 10, 23, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            Location = "3012 Peach Orchard Rd, Augusta, GA 30906",
                            Name = "Cookout",
                            StartDate = new DateTime(2021, 10, 23, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Fam"
                        },
                        new
                        {
                            EventID = 4,
                            Branch = "Augusta, GA",
                            Description = "Tech Tuesday training on what's new in .NET 5.",
                            EndDate = new DateTime(2021, 10, 26, 9, 30, 0, 0, DateTimeKind.Unspecified),
                            Location = "The Alan Turing room",
                            Name = ".NET 5: Whats New?!",
                            StartDate = new DateTime(2021, 10, 26, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Edu"
                        },
                        new
                        {
                            EventID = 5,
                            Branch = "Augusta, GA",
                            Description = "Wear your best costume!",
                            EndDate = new DateTime(2021, 10, 30, 16, 30, 0, 0, DateTimeKind.Unspecified),
                            Location = "1450 Greene St #200, Augusta, GA 30901",
                            Name = "Costume Day!",
                            StartDate = new DateTime(2021, 10, 30, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Fun"
                        });
                });

            modelBuilder.Entity("RSI_Calendar.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RSI_Calendar.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RSI_Calendar.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RSI_Calendar.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RSI_Calendar.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}