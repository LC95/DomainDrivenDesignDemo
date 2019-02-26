namespace Arch.UseCase.UseCases.ContactAgent
{
    public interface IRequestHandler<TRequest, TResponse>
    {
        TResponse Handle(TRequest request);
    }
}