using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.Contracts.Modules;

namespace TradingCompany.Contracts.Persistence
{
    public interface ICondition : IIdentifiable, ICopyable<ICondition>
    {
        int ProductId { get; set; }
        int CustomerId { get; set; }
        ConditionType ConditionType { get; set; }

        double Quantity { get; set; }

        double Value { get; set; }
        
        string Note { get; set; }

    }
}
