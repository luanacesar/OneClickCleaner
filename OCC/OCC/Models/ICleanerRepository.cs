using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCC.Models
{
    public interface ICleanerRepository
    {
        IQueryable<Cleaner> Cleaners { get; }

        void SaveCleaner(Cleaner cleaner);

        //Cleaner DeleteProduct(int cleanerID);
    }
}
