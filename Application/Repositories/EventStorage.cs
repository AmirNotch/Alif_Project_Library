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
    
    public async Task<bool> CreateEventStorage(CardEvent cardEvent)
    {
        await _context.CardEvents.AddAsync(cardEvent);
        return await Save();
    }

    public async Task<bool> Save()
    {
        var saved = await _context.SaveChangesAsync();
        return saved >= 0;
    }
}