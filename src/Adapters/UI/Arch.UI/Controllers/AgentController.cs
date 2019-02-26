using System.Collections.Generic;
using Arch.Api.Presenters;
using Arch.Api.ViewModels;
using Arch.UseCase.UseCases.ContactAgent;
using Microsoft.AspNetCore.Mvc;

namespace Arch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly ContactAgentInteractor _interactor;
        private readonly ContactAgentResponsePresenter _presenter;
        public AgentController(ContactAgentInteractor interactor, ContactAgentResponsePresenter presenter)
        {
            _interactor = interactor;
            _presenter = presenter;
        }

        public ActionResult<ContactAgentResponseViewModel> Contact(ContactAgentRequestMessage requestMessage)
        {
            var response = _interactor.Handle(requestMessage);
            var viewModel = _presenter.Handle(response);
            return viewModel;
        }
    }
}
