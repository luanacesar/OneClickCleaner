using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCC.Models
{
    public class SeedCleaner
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            if (!context.Cleaners.Any())
            {
                context.Cleaners.AddRange(
                    new Cleaner
                    {
                        FirstName = "Mary",
                        Email = "mary_smith@gmail.com",
                        Location = "Toronto",
                        IsCleaner = true,
                        ExperienceLevel = "High",
                        Certificate = "CSC2489001",
                        BankAccount = 0046448300,
                        Morning=true,
                        Afternoon=true,
                        Evening=true,
                        Night=false,
                        Weekends=false
                    },
                    new Cleaner
                    {
                        FirstName = "Jhosua",
                        Email = "jhosua@gmail.com",
                        Location = "Toronto",
                        IsCleaner = true,
                        ExperienceLevel = "High",
                        Certificate = "CSC2489010",
                        BankAccount = 0046448400,
                        Morning = true,
                        Afternoon = true,
                        Evening = true,
                        Night = false,
                        Weekends = false
                    },
                    new Cleaner
                    {
                        FirstName = "Peter",
                        Email = "peter@gmail.com",
                        Location = "York",
                        IsCleaner = true,
                        ExperienceLevel = "High",
                        Certificate = "CSC2489002",
                        BankAccount = 0123456789,
                        Morning = true,
                        Afternoon = true,
                        Evening = true,
                        Night = true,
                        Weekends = true
                    },
                    new Cleaner
                    {
                        FirstName = "Maria",
                        Email = "maria@gmail.com",
                        Location = "York",
                        IsCleaner = true,
                        ExperienceLevel = "High",
                        Certificate = "CSC2489033",
                        BankAccount = 2223456789,
                        Morning = true,
                        Afternoon = true,
                        Evening = false,
                        Night = false,
                        Weekends = true
                    },
                    new Cleaner
                    {
                        FirstName = "Jake",
                        Email = "jake@gmail.com",
                        Location = "York",
                        IsCleaner = true,
                        ExperienceLevel = "High",
                        Certificate = "CSC2489099",
                        BankAccount = 5553456789,
                        Morning = true,
                        Afternoon = false,
                        Evening = false,
                        Night = true,
                        Weekends = true
                    },
                    new Cleaner
                    {
                        FirstName = "Sophy",
                        Email = "sophy@gmail.com",
                        Location = "Durkham",
                        IsCleaner = true,
                        ExperienceLevel = "Medium",
                        Certificate = "CSC2489002",
                        BankAccount = 3456234560,
                        Morning = true,
                        Afternoon = false,
                        Evening = false,
                        Night = true,
                        Weekends = false
                    },
                    new Cleaner
                    {
                        FirstName = "Federic",
                        Email = "diallo@gmail.com",
                        Location = "Peel",
                        IsCleaner = true,
                        ExperienceLevel = "High",
                        Certificate = "CSC2489002",
                        BankAccount = 0248286930,
                        Morning = false,
                        Afternoon = true,
                        Evening = true,
                        Night = false,
                        Weekends = true
                    },
                    new Cleaner
                    {
                        FirstName = "Steven",
                        Email = "thomas@gmail.com",
                        Location = "Halton",
                        IsCleaner = true,
                        ExperienceLevel = "High",
                        Certificate = "CSC2489002",
                        BankAccount = 4928472856,
                        Morning = true,
                        Afternoon = true,
                        Evening = true,
                        Night = true,
                        Weekends = false
                    }

                );

                context.SaveChanges();
            }

        }
    }
}
