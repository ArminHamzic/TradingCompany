using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.Contracts.Persistence;

namespace TradingCompany.Logic.Entities.Persistence
{
    internal class Customer : IdentityObject, Contracts.Persistence.ICustomer
    {
        public string Number { get; set; }
        public string Name { get; set; }

        public void CopyProperties(ICustomer other)
        {
            Id = other.Id;
            Number = other.Number;
            Name = other.Name;

        }
    }
}
