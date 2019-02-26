using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arch.Api.ViewModels {
    public class ContactAgentResponseViewModel {
        public ContactAgentResponseViewModel(string text)
        {
            Text = text;
        }

        public string Text { get; set; }

        
    }
}
