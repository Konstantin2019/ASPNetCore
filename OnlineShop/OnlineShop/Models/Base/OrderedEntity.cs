using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.Base
{
    public class OrderedEntity : NamedEntity
    {
        public int Order { get; set; }
    }
}
