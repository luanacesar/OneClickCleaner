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
                        FullName = "Mary Smith",
                        Location = "Toronto",
                        ExperienceLevel = "High"
                    },
                    new Cleaner
                    {
                        FullName = "Peter Bell",
                        Location = "York",
                        ExperienceLevel = "High"
                    },
                    new Cleaner
                    {
                        FullName = "Sophy Graham",
                        Location = "Durkham",
                        ExperienceLevel = "Medium"
                    },
                    new Cleaner
                    {
                        FullName = "Federic Diallo",
                        Location = "Peel",
                        ExperienceLevel = "High"
                    },
                    new Cleaner
                    {
                        FullName = "Steven Thomas",
                        Location = "Halton",
                        ExperienceLevel = "High"
                    }

                );

                context.SaveChanges();
            }

        }
    }
}
