using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.Contracts.Persistence;

namespace TradingCompany.Logic.Entities.Persistence
{
    internal class Product : IdentityObject, Contracts.Persistence.IProduct
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public void CopyProperties(IProduct other)
        {
            Id = other.Id;
            Number = other.Number;
            Name = other.Name;
            Price = other.Price;
        }
    }
}
