using Arch.Domain.ValueObjects;
using System.Collections.Generic;
using Arch.Domain.Core.Models;

namespace Arch.Domain.Entities {
    public class House :Entity {
        public long? HouseId { get; set; }
        public string Address { get;set;}

        public IList<Interest> Leads { get;}

        public House()
        {
            Leads = new List<Interest>();
        }

        public void RegisterInterest(Interest interest)
        {
            Leads.Add(interest);
        }
    }
}