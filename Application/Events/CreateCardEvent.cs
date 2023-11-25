using Application.Core;
using Entity;
using MediatR;
using Persistence;

namespace Application.Events;

public class CreateCardEvent
{
    public class Command : IRequest<Result<Unit>>
    {
        public CardEvent CardEvent { get; set; }
    }
    
    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }
            
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            _context.CardEvents.Add(request.CardEvent);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result)
            {
                return Result<Unit>.Failure("Failed to create activity");
            }
                
            return Result<Unit>.Success(Unit.Value);
        }
    }
}