using Arch.Api.ViewModels;
using Arch.UseCase.UseCases.ContactAgent;
using System.Text;

namespace Arch.Api.Presenters {
    public class ContactAgentResponsePresenter {
        public ContactAgentResponseViewModel Handle(ContactAgentResponseMessage response)
        {
            switch (response.ValidationResult.IsValid)
            {
                case true:
                    return new ContactAgentResponseViewModel("Thank you");
                case false:
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("Validation Error");
                    foreach (var error in response.ValidationResult.Errors)
                    {
                        sb.AppendLine(error.ErrorMessage);
                    }
                    return new ContactAgentResponseViewModel(sb.ToString());
                }
            }
            return null;

        }
    }
}