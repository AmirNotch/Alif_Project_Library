using Entity;
using Newtonsoft.Json;
using Persistence;
using Formatting = System.Xml.Formatting;

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
        if (saved > 0)
        {
            string json = JsonConvert.SerializeObject(cardEvent, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);
            return cardEvent;
        }
        else
            return null;
    }
}