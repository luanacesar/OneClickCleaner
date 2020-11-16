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
            context.SaveChanges();
        }
    }
}
