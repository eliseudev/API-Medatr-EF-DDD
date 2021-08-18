using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VemDeZap.Infra.Transactions
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
