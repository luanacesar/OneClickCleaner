using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCC.Models
{
    public class EFCustomerRepository:ICustomerRepository
    {
        private ApplicationDbContext context;

        public EFCustomerRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Customer> Customers => context.Customers;

        public void SaveCustomer(Customer customer)
        {
            if (customer.CustomerId==0)
            {
                context.Customers.Add(customer);
            }
            context.SaveChanges();
        }
    }
}
