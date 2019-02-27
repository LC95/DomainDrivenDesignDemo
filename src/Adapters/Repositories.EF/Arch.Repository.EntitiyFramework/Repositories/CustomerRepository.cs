using System;
using System.Linq;
using Arch.Data.EntityFramework.Context;
using Arch.Domain.Entities;
using Arch.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Arch.Data.EntityFramework.Repositories {
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
