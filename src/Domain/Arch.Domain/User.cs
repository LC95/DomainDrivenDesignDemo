using System;

namespace Arch.Domain
{
    public class User
    {
        public User(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }

        public string Name { get; set; }
    }
}
