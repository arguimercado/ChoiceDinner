using MediatR;

namespace ChoiceDinner.Application.Extensions
{
    public interface ICommand<TRequest> : IRequest<TRequest> 
    {
        
    }
}