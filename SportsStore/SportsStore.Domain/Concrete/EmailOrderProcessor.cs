﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Abstract;

namespace SportsStore.Domain.Concrete
{
    public class EmailOrderProcessor :IOrderProcessor
    {

        public void ProcessOrder(Entities.Cart cart, Entities.ShippingDetails shippingDetails)
        {
            
        }
    }
}
