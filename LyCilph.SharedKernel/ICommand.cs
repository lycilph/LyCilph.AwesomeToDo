using MediatR;

namespace LyCilph.SharedKernel;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}