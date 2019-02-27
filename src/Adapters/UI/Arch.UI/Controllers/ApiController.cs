﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arch.Domain.Core.Bus;
using Arch.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Arch.Api.Controllers {
    public class ApiController : ControllerBase {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;
        protected IEnumerable<DomainNotification> Notifications=> _notifications.GetNotifications();

        protected ApiController(INotificationHandler<DomainNotification> notificationHandler, IMediatorHandler mediator)
        {
            _notifications = (DomainNotificationHandler)notificationHandler;
            _mediator = mediator;
        }

        protected bool IsValidOperation()
        {
            return !_notifications.HasNotifications();
        }

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new{ 
                    success = true,
                    data = result
                });
            }
            return BadRequest(new { 
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }
        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(string.Empty, erroMsg);
            }
        }

        protected void NotifyError(string code, string message)
        {
            _mediator.RaiseEvent(new DomainNotification(code, message));
        }

        protected void AddIdentityErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                NotifyError(result.ToString(), error.Description);
            }
        }
    }
}