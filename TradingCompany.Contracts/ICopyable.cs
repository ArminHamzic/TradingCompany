using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompany.Contracts
{
    public partial interface ICopyable<T>
    {
        void CopyProperties(T other);
    }
}
