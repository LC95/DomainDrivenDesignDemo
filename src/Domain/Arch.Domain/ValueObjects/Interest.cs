using System;

namespace Arch.Domain.ValueObjects {
    public class Interest {
        public string CustomerEmailAddress { get; set; }
        public long CustomerPhoneNumber { get;set;}
        public DateTime CreationDate { get;set;}
    }
}