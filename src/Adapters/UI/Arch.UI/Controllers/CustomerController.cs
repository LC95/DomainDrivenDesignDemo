using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arch.Domain.Core.Bus;
using Arch.Domain.Core.Notifications;
using Arch.UseCase.Port;
using Arch.UseCase.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arch.Api.Controllers {
    public class CustomerController : ApiController{
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(INotificationHandler<DomainNotification> notificationHandler, IMediatorHandler mediator, ICustomerAppService customerAppService) : base(notificationHandler, mediator)
        {
            _customerAppService = customerAppService;
        }
        public CustomerController(
           ICustomerAppService customerAppService,
           INotificationHandler<DomainNotification> notifications,
           IMediatorHandler mediator) : base(notifications, mediator)
        {
            _customerAppService = customerAppService;
        }

        [HttpGet]
        [Route("customer-management")]
        public IActionResult Get()
        {
            return Response(_customerAppService.GetAll());
        }

        [HttpGet]
        [Route("customer-management/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var customerViewModel = _customerAppService.GetById(id);

            return Response(customerViewModel);
        }

        [HttpPost]
        [Route("customer-management")]
        public IActionResult Post([FromBody]CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            _customerAppService.Register(customerViewModel);

            return Response(customerViewModel);
        }

        [HttpPut]
        [Route("customer-management")]
        public IActionResult Put([FromBody]CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            _customerAppService.Update(customerViewModel);

            return Response(customerViewModel);
        }

        [HttpDelete]
        [Route("customer-management")]
        public IActionResult Delete(Guid id)
        {
            _customerAppService.Remove(id);

            return Response();
        }
    }
}
