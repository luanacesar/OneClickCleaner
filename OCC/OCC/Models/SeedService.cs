using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCC.Models
{
    public class SeedService
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            const double PRICE_EMERGENCY_SERV_PER_HOUR = 70.0;
            const double PRICE_BOOKING_SERV_PER_HOUR = 50.0;

            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            if (!context.Services.Any())
            {
                context.Services.AddRange(
                    new Service
                    {
                        Type="Emergency",
                        Price= PRICE_EMERGENCY_SERV_PER_HOUR
                    },
                    new Service
                    {
                        Type = "Booking",
                        Price = PRICE_BOOKING_SERV_PER_HOUR
                    }
                );

                context.SaveChanges();
            }

        }
    }
}
