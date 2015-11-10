using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EFCustomerRepository: ICustomerRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Customer> customer
        {
            get { return context.Customers; }
        }
    }
}
