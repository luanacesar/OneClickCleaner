using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCC.Models
{
    public class EFCleanerRepository:ICleanerRepository
    {
        private ApplicationDbContext context;

        public EFCleanerRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Cleaner> Cleaners => context.Cleaners;

        public void SaveCleaner(Cleaner cleaner)
        {
            if (cleaner.CleanerId == 0)
            {
                context.Cleaners.Add(cleaner);
            }
            else
            {
                Cleaner cleanerEntry = context.Cleaners
                    .FirstOrDefault(p => p.CleanerId == cleaner.CleanerId);

                if (cleanerEntry != null)
                {
                    cleanerEntry.FirstName = cleaner.FirstName;
                    cleanerEntry.IsCleaner = cleaner.IsCleaner;
                    cleanerEntry.Email = cleaner.Email;
                    cleanerEntry.Location = cleaner.Location;
                    cleanerEntry.BankAccount = cleaner.BankAccount;
                    cleanerEntry.ExperienceLevel = cleaner.ExperienceLevel;
                    cleanerEntry.Certificate = cleaner.Certificate;
                    cleanerEntry.Weekends = cleaner.Weekends;
                    cleanerEntry.Afternoon = cleaner.Afternoon;
                    cleanerEntry.Morning = cleaner.Morning;
                    cleanerEntry.Evening = cleaner.Evening;
                    cleanerEntry.Night = cleaner.Night;
                    cleanerEntry.Password = cleaner.Password;
                    cleanerEntry.UserName = cleaner.UserName;
                }
            }
            context.SaveChanges();
        }
        public Cleaner DeleteCleaner(int cleanerID)
        {
            Cleaner cleanerEntry = context.Cleaners
                .FirstOrDefault(p => p.CleanerId == cleanerID);

            if (cleanerEntry != null)
            {
                context.Cleaners.Remove(cleanerEntry);
                context.SaveChanges();
            }

            return cleanerEntry;
        }
    }
}
