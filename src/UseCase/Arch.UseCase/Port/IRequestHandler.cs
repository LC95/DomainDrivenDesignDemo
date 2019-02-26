namespace Arch.UseCase.Port
{
    public interface IRequestHandler<TRequest, TResponse>
    {
        TResponse Handle(TRequest request);
    }
}