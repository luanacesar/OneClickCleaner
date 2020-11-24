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
                Cleaner productEntry = context.Cleaners
                    .FirstOrDefault(p => p.CleanerId == cleaner.CleanerId);

                if (productEntry != null)
                {
                    productEntry.FirstName = cleaner.FirstName;
                    productEntry.IsCleaner = cleaner.IsCleaner;
                    productEntry.Email = cleaner.Email;
                    productEntry.ExperienceLevel = cleaner.ExperienceLevel;
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
