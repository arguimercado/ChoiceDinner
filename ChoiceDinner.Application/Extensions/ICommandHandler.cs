using MediatR;

namespace ChoiceDinner.Application.Extensions
{
    public interface ICommandHandler<TCommand,TResponse> : IRequestHandler<TCommand,TResponse> 
        where TCommand : ICommand<TResponse>
    {
        
    }
}