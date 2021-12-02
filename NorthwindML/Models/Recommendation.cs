using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindML.Models
{
    public class Recommendation
    {
        public uint CoboughtProductID { get; set; }
        public float Score { get; set; }
    }
}
