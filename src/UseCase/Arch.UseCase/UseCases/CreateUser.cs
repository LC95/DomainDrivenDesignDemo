using Arch.Domain;
using Arch.UseCase.Port;

namespace Arch.UseCase.UseCases
{
    public class CreateUser
    {
        private readonly IUserRepository _repository;
        private readonly IIdGenerator _idGenerator;

        public CreateUser(IIdGenerator idGenerator, IUserRepository repository)
        {
            this._idGenerator = idGenerator;
            this._repository = repository;
        }

        public void Save(string name)
        {
            var id = _idGenerator.GenerateId();
            var user = new User(id,name);
            _repository.Save(user);
        }
        
    }
}
