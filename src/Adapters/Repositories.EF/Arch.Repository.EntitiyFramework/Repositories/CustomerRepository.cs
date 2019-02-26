using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arch.Domain.Core.Models;
using Arch.Domain.Entities;
using Arch.Domain.Repositories;
using Arch.Repository.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Arch.Repository.EntityFramework.Repositories {
    public class CustomerRepository : Repository<Guid,Customer>, ICustomerRepository {
        public CustomerRepository(ArchContext db) : base(db)
        {
        }

        public Customer GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
