namespace Arch.Domain.Core.Models {
    public interface IUnitOfWork {
        bool Commit();
    }
}
