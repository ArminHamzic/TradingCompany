using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompany.Logic.Entities
{
    public class IdentityObject : Contracts.IIdentifiable
    {
        public int Id { get; set; }
    }
}
