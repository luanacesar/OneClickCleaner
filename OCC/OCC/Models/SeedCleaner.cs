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
                        BankAccount = 0046448300

                    },
                    new Cleaner
                    {
                        FirstName = "Peter",
                        Email = "peter@gmail.com",
                        Location = "York",
                        IsCleaner = true,
                        ExperienceLevel = "High",
                        Certificate = "CSC2489002",
                        BankAccount = 0123456789
                    },
                    new Cleaner
                    {
                        FirstName = "Sophy",
                        Email = "sophy@gmail.com",
                        Location = "Durkham",
                        IsCleaner = true,
                        ExperienceLevel = "Medium",
                        Certificate = "CSC2489002",
                        BankAccount = 3456234560
                    },
                    new Cleaner
                    {
                        FirstName = "Federic",
                        Email = "diallo@gmail.com",
                        Location = "Peel",
                        IsCleaner = true,
                        ExperienceLevel = "High",
                        Certificate = "CSC2489002",
                        BankAccount = 0248286930
                    },
                    new Cleaner
                    {
                        FirstName = "Steven",
                        Email = "thomas@gmail.com",
                        Location = "Halton",
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
