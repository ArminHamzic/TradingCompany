using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.Contracts.Modules;
using TradingCompany.Contracts.Persistence;

namespace TradingCompany.Logic.Entities.Persistence
{
    internal class Condition : IdentityObject, Contracts.Persistence.ICondition
    {
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        public ConditionType ConditionType { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public double Quantity { get; set; }
        public string Note { get; set; }
        public double Value { get; set; }

        public void CopyProperties(ICondition other)
        {
            Id = other.Id;
            ProductId = other.ProductId;
            CustomerId = other.CustomerId;
            ConditionType = other.ConditionType;
            Quantity = other.Quantity;
            Note = other.Note;
            Value = other.Value;
        }
    }
}
