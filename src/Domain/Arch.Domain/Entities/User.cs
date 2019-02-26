using Arch.Domain.Core.Models;

namespace Arch.Domain.Entities
{
    public class User : Entity
    {
        public User(string userId, string name)
        {
            UserId = userId;
            Name = name;
        }

        public string UserId { get; set; }

        public string Name { get; set; }
    }
}
