using Arch.UseCase.Port;
using System;

namespace Arch.Infrastructure {
    public class GuidIdGenerator : IIdGenerator {
        public string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
