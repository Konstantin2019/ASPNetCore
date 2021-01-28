using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.Base
{
    public class NamedEntity : IDEntity
    {
        public string Name { get; set; }
    }
}
