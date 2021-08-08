using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthDemo2.Services
{
    public interface IUnitOfWork<T> where T : class
    {
        IRepository<T> Entity { get; init; }

        Task Save();
    }
}
