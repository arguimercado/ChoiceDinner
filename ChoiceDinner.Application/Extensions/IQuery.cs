using MediatR;

namespace ChoiceDinner.Application.Extensions
{
    public interface IQuery<TRequest> : IRequest<TRequest>
    {
        
    }
}