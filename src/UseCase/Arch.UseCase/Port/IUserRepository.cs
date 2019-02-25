using Arch.Domain;

namespace Arch.UseCase.Port
{
    public interface IUserRepository
    {
        void Save(User user);
    }
}