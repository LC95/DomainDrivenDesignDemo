using System;
using System.Collections.Generic;
using System.Text;
using Arch.Domain.Core.Models;
using Arch.Domain.Entities;

namespace Arch.Domain.Repositories {
    public interface ICustomerRepository : IRepository<Guid,Customer> {
        Customer GetByEmail(string email);
    }
}
