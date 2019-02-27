using System;
using System.Collections.Generic;
using System.Text;
using Arch.UseCase.ViewModels;

namespace Arch.UseCase.Port {
    public interface ICustomerAppService : IDisposable {
        void Register(CustomerViewModel customerViewModel);
        IEnumerable<CustomerViewModel> GetAll();
        CustomerViewModel GetById(Guid id);
        void Update(CustomerViewModel customerViewModel);
        void Remove(Guid id);
    }
}
