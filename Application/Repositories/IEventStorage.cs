using Entity;

namespace Application.Repositories;

public interface IEventStorage
{
    Task<CardEvent> CreateEventStorage(CardEvent cardEvent);
    //Task<bool> Save();
}