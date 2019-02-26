using System;
using System.Collections.Generic;
using System.Text;
using Arch.Domain.Entities;

namespace Arch.Domain.Repositories {
    public interface IHouseRepository : IRepository<string, House> {
    }
}
