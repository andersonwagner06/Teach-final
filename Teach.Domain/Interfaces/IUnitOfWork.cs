using System;
using System.Threading.Tasks;

namespace Teach.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
