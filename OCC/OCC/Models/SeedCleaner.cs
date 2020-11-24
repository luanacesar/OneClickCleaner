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
                        Certificate = "3356289",
                        BankAccount = 0046448300,
                        Morning=true,
                        Afternoon=true,
                        Evening=true,
                        Night=false,
                        Weekends= true
                    },
                    new Cleaner
                    {
                        FirstName = "Jhosua",
                        Email = "jhosua@gmail.com",
                        Location = "Toronto",
                        IsCleaner = true,
                        ExperienceLevel = "High",
                        Certificate = "9982234",
                        BankAccount = 0046448400,
                        Morning = true,
                        Afternoon = true,
                        Evening = true,
                        Night = false,
                        Weekends = false
                    },
                    new Cleaner
                    {
                        FirstName = "Rob",
                        Email = "rob@gmail.com",
                        Location = "Toronto",
                        IsCleaner = true,
                        ExperienceLevel = "Intermediate",
                        Certificate = "7734561",
                        BankAccount = 0046455500,
                        Morning = false,
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
                        Certificate = "7623400",
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
                        Certificate = "11297600",
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
                        Certificate = "85532900",
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
                        ExperienceLevel = "Intermediate",
                        Certificate = "42881900",
                        BankAccount = 3456234560,
                        Morning = true,
                        Afternoon = false,
                        Evening = false,
                        Night = true,
                        Weekends = false
                    },
                    new Cleaner
                    {
                        FirstName = "Noah",
                        Email = "noah@gmail.com",
                        Location = "Durkham",
                        IsCleaner = true,
                        ExperienceLevel = "High",
                        Certificate = "5211338",
                        BankAccount = 0236234560,
                        Morning = false,
                        Afternoon = false,
                        Evening = false,
                        Night = true,
                        Weekends = true
                    },
                     new Cleaner
                     {
                         FirstName = "Mia",
                         Email = "miasw@gmail.com",
                         Location = "Durkham",
                         IsCleaner = true,
                         ExperienceLevel = "High",
                         Certificate = "00447321",
                         BankAccount = 1236234771,
                         Morning = true,
                         Afternoon = true,
                         Evening = true,
                         Night = true,
                         Weekends = true
                     },
                    new Cleaner
                    {
                        FirstName = "Federic",
                        Email = "diallo@gmail.com",
                        Location = "Peel",
                        IsCleaner = true,
                        ExperienceLevel = "High",
                        Certificate = "0542986",
                        BankAccount = 0248286930,
                        Morning = false,
                        Afternoon = true,
                        Evening = true,
                        Night = false,
                        Weekends = true
                    },
                    new Cleaner
                    {
                        FirstName = "Emma",
                        Email = "emma@gmail.com",
                        Location = "Peel",
                        IsCleaner = true,
                        ExperienceLevel = "Intermediate",
                        Certificate = "3997521",
                        BankAccount = 1448286923,
                        Morning = true,
                        Afternoon = true,
                        Evening = true,
                        Night = true,
                        Weekends = false
                    },
                    new Cleaner
                    {
                        FirstName = "George",
                        Email = "ggeorge@gmail.com",
                        Location = "Peel",
                        IsCleaner = true,
                        ExperienceLevel = "High",
                        Certificate = "8854209",
                        BankAccount = 5332286977,
                        Morning = false,
                        Afternoon = true,
                        Evening = true,
                        Night = false,
                        Weekends = true,
                    },
                    new Cleaner
                    {
                        FirstName = "Jhon",
                        Email = "jhonb@gmail.com",
                        Location = "Halton",
                        IsCleaner = true,
                        ExperienceLevel = "Intermediate",
                        Certificate = "66290345",
                        BankAccount = 8866234509,
                        Morning = false,
                        Afternoon = false,
                        Evening = true,
                        Night = true,
                        Weekends = true
                    },
                    new Cleaner
                    {
                        FirstName = "Annie",
                        Email = "annie@gmail.com",
                        Location = "Halton",
                        IsCleaner = true,
                        ExperienceLevel = "High",
                        Certificate = "88863076",
                        BankAccount = 9976233409,
                        Morning = true,
                        Afternoon = true,
                        Evening = false,
                        Night = false,
                        Weekends = false
                    },
                    new Cleaner
                    {
                        FirstName = "Steven",
                        Email = "thomas@gmail.com",
                        Location = "Halton",
                        IsCleaner = true,
                        ExperienceLevel = "High",
                        Certificate = "88455780",
                        BankAccount = 4928445656,
                        Morning = true,
                        Afternoon = true,
                        Evening = true,
                        Night = true,
                        Weekends = false
                    },
                    new Cleaner
                    {
                        FirstName = "Ava",
                        Email = "avaa@gmail.com",
                        Location = "Halton",
                        IsCleaner = false,
                        ExperienceLevel = "Beginner",
                        Certificate = "28255554",
                        BankAccount = 7632100988,
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
