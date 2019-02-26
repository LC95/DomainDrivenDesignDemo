using System.Collections.Generic;

namespace Arch.UseCase.Results {
    public class ValidationResult {
        public bool IsValid { get; set; }
        public IEnumerable<Error> Errors { get; set; }
    }
}
