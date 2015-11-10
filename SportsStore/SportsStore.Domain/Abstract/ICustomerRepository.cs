using System;
using System.Collections.Generic;
using System.Text;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Abstract
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> customer { get; }
    }
}
