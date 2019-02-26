using Arch.Domain;
using Arch.Domain.Entities;

namespace Arch.UseCase.Port
{
    public interface IUserRepository
    {
        void Save(User user);
    }
}