using Arch.Domain.Commands;
using Arch.Domain.Core.Bus;
using Arch.Domain.Repositories;
using Arch.UseCase.Port;
using Arch.UseCase.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;

namespace Arch.UseCase.UseCases.Customer {
    public class CustomerAppService : ICustomerAppService {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediatorHandler _bus;

        public CustomerAppService(IMapper mapper,
                                  ICustomerRepository customerRepository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _bus = bus;
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            return _customerRepository.GetAll().ProjectTo<CustomerViewModel>(_mapper.ConfigurationProvider);
        }

        public CustomerViewModel GetById(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(_customerRepository.GetById(id));
        }

        public void Register(CustomerViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewCustomerCommand>(customerViewModel);
            _bus.SendCommand(registerCommand);
        }

        public void Update(CustomerViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel);
            _bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveCustomerCommand(id);
            _bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
