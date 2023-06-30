using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bogus.Fakers
{
    public class OrderFaker : BaseFaker<Order>
    {
        public OrderFaker()
        {
            RuleFor(x => x.DateTime, x => x.Date.Past());
        }

    }
}
