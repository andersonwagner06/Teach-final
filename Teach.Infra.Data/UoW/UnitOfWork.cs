using System.Threading.Tasks;
using Teach.Domain.Interfaces;
using Teach.Infra.Data.Context;

namespace Teach.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TeachContext _context;

        public UnitOfWork(TeachContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
