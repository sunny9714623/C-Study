using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindML.Models
{
    public class Cart
    {
        public IEnumerable<CartItem> Items { get; set; }
    }
}
