using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.Contracts.Persistence;

namespace TradingCompany.Logic.Entities.Persistence
{
    internal class Order : IdentityObject, Contracts.Persistence.IOrder
    {
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public int Count { get; set; }
        public double Discount { get; set; }

        public Customer Customer { get; set; }

        public Product Product { get; set; }
        public double NetPrice { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; }

        public void CopyProperties(IOrder other)
        {
            Id = other.Id;
            CustomerId = other.CustomerId;
            ProductId = other.ProductId;
            Count = other.Count;
            Discount = other.Discount;
            NetPrice = other.NetPrice;
        }

    }
}
