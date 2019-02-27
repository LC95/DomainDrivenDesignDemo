using Arch.Data.EntityFramework.Context;
using Arch.Domain.Core.Models;

namespace Arch.Data.EntityFramework.UoW {
    public class UnitOfWork : IUnitOfWork {
        private readonly ArchContext _context;

        public UnitOfWork(ArchContext context)
        {
            _context = context;
        }
        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
