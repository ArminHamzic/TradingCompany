using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompany.Contracts.Persistence
{
    public interface ICustomer : IIdentifiable, ICopyable<ICustomer>
    {
        string Number { get; set; }
        string Name { get; set; }
    }
}
