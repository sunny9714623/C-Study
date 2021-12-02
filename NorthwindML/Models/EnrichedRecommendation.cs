using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindML.Models
{
    public class EnrichedRecommendation : Recommendation
    {
        public string ProductName { get; set; }
    }
}
