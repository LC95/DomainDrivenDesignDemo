using Arch.Domain.Core.Models;
using Arch.Repository.EntityFramework.Context;

namespace Arch.Repository.EntityFramework.UoW {
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
