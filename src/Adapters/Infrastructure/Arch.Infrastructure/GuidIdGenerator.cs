using System;
using Arch.UseCase;
using Arch.UseCase.Port;

namespace Arch.Infrastructure
{
    public class GuidIdGenerator : IIdGenerator
    {
        public string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
