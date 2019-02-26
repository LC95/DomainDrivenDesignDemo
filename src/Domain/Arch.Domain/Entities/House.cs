using System.Collections.Generic;
using Arch.Domain.ValueObjects;

namespace Arch.Domain.Entities
{
    public class House
    {
        public House(List<Interest> interests)
        {
            Interests = interests;
        }

        public List<Interest> Interests { get;}

        public void RegisterInterest(Interest interest)
        {
            Interests.Add(interest);
        }
    }
}