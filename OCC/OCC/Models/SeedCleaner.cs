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
                        LastName = "Smith",
                        Email = "mary_smith@gmail.com",
                        Phone = 4167298931,
                        Location = "Toronto",
                        PostalCode = "M5C-2X5",
                        IsCleaner = true,
                        ExperienceLevel = "High",
                        Certificate = "CSC2489001",
                        BankAccount = 0046448300

                    },
                    new Cleaner
                    {
                        FirstName = "Peter",
                        LastName = "Bell",
                        Email = "peter@gmail.com",
                        Phone = 6473272224,
                        Location = "York",
                        PostalCode = "M5C-2X5",
                        IsCleaner = true,
                        ExperienceLevel = "High",
                        Certificate = "CSC2489002",
                        BankAccount = 0123456789
                    },
                    new Cleaner
                    {
                        FirstName = "Sophy",
                        LastName = "Graham",
                        Email = "sophy@gmail.com",
                        Phone = 6475550990,
                        Location = "Durkham",
                        PostalCode = "M5C-2X5",
                        IsCleaner = true,
                        ExperienceLevel = "Medium",
                        Certificate = "CSC2489002",
                        BankAccount = 3456234560
                    },
                    new Cleaner
                    {
                        FirstName = "Federic",
                        LastName = "Diallo",
                        Email = "diallo@gmail.com",
                        Phone = 6475050304,
                        Location = "Peel",
                        PostalCode = "M5C-2X5",
                        IsCleaner = true,
                        ExperienceLevel = "High",
                        Certificate = "CSC2489002",
                        BankAccount = 0248286930
                    },
                    new Cleaner
                    {
                        FirstName = "Steven",
                        LastName = "Thomas",
                        Email = "thomas@gmail.com",
                        Phone = 4026442020,
                        Location = "Halton",
                        PostalCode = "M5C-2X5",
                        IsCleaner = true,
                        ExperienceLevel = "High",
                        Certificate = "CSC2489002",
                        BankAccount = 4928472856
                    }

                );

                context.SaveChanges();
            }

        }
    }
}
