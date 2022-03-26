using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xyz.Multitenancy.Models
{
    public class MultitenancyConfiguration
    {
        public IDictionary<string, string> ConnectionStrings { get; set; } = default!;
    }
}
