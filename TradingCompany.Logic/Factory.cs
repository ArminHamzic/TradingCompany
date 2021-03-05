using CommonBase.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.Contracts;
using TradingCompany.Contracts.Client;

namespace TradingCompany.Logic
{
    public static class Factory
    {
        public enum PersistenceType
        {
            Db,
            Csv,
            Ser,
        }
        public static PersistenceType Persistence { get; set; } = Factory.PersistenceType.Db;
        private static DataContext.IContext CreateContext()
        {
            DataContext.IContext result = null;

            if (Persistence == PersistenceType.Db)
            {
                result = new DataContext.DB.TradingCompanyDbContext();
            }
            return result;
        }

        public static IController<T> Create<T>() where T : Contracts.IIdentifiable
        {
            IController<T> result = null;

            if (typeof(T) == typeof(Contracts.Persistence.IProduct))
            {
                result = (IController<T>)CreateProductController();
            }
            else if (typeof(T) == typeof(Contracts.Persistence.ICustomer))
            {
                result = (IController<T>)CreateCustomerController();
            }
            else if (typeof(T) == typeof(Contracts.Persistence.ICondition))
            {
                result = (IController<T>)CreateConditionController();
            }
            else if (typeof(T) == typeof(Contracts.Persistence.IOrder))
            {
                result = (IController<T>)CreateOrderController();
            }
            return result;
        }

        private static IController<IIdentifiable> CreateOrderController()
        {
            throw new NotImplementedException();
        }

        private static IController<IIdentifiable> CreateConditionController()
        {
            throw new NotImplementedException();
        }

        private static IController<IIdentifiable> CreateCustomerController()
        {
            throw new NotImplementedException();
        }

        private static IController<IIdentifiable> CreateProductController()
        {
            throw new NotImplementedException();
        }

 
    }
}
