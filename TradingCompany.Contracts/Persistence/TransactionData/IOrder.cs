using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompany.Contracts.Persistence
{
    public interface IOrder : IIdentifiable, ICopyable<IOrder>
    {
        int ProductId { get; set; }
        int CustomerId { get; set; }
        int Count { get; set; }
        double Discount { get; set; }
        double NetPrice { get; set; }
        DateTime CreatedOn { get; }
    }
}
