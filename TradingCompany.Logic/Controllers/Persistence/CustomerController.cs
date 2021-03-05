using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.Logic.DataContext;

namespace TradingCompany.Logic.Controllers.Persistence
{
    internal abstract partial class CustomerController<E, I> : GenericController<E, I>
        where E : Entities.IdentityObject, I, Contracts.ICopyable<I>, new()
        where I : Contracts.IIdentifiable
    {
        internal IContext ProductContext => (IContext)Context;

        protected CustomerController(IContext context)
            : base(context)
        {
        }
        protected CustomerController(ControllerObject controller)
            : base(controller)
        {
        }
    }
}
