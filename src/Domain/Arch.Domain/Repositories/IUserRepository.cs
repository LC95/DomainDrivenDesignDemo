using Arch.Domain.Core.Models;
using Arch.Domain.Entities;

namespace Arch.Domain.Repositories
{
    public interface IUserRepository : IRepository<string, User>
    {
        
    }
}