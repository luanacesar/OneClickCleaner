using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCC.Models
{
    public class EFServiceRepository:IServiceRepository
    {
        private ApplicationDbContext context;

        public EFServiceRepository(ApplicationDbContext ctxt)
        {
            context = ctxt;
        }

        public IQueryable<Service> Services => context.Services;

        public void SaveService(Service service)
        {
            if (service.ServiceId==0)
            {
                context.Services.Add(service);
            }

            context.SaveChanges();
        }
    }
}
