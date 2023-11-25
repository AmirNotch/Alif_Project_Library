using Entity;

namespace Application.Repositories;

public interface IEventStorage
{
    Task<bool> CreateEventStorage(CardEvent cardEvent);
    Task<bool> Save();
}