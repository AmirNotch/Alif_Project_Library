using Entity;
using Persistence;

namespace Application.Repositories;

public class EventStorage : IEventStorage
{
    private readonly DataContext _context;
    
    public EventStorage(DataContext context)
    {
        _context = context;
    }
    
    public async Task<CardEvent> CreateEventStorage(CardEvent cardEvent)
    {
        _context.CardEvents.Add(cardEvent);
        var saved = await _context.SaveChangesAsync();
        return saved > 0 ? cardEvent : null;
    }
}