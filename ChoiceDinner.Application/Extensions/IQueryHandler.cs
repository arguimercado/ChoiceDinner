using MediatR;

namespace ChoiceDinner.Application.Extensions;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse> 
    where TQuery : IQuery<TResponse>
{
    
}