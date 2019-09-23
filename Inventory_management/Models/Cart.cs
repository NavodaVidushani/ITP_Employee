using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_management.Models
{
    public class Cart
    {
        public storeproduct Storeproduct { get; set; }

        public int Quantity { get; set; }

        public Cart(storeproduct storeproduct, int quantity)
        {
            Storeproduct = storeproduct;
            Quantity = quantity;

        }

    }
}
