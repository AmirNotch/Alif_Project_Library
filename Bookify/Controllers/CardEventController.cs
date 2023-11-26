using System.Net;
using Application.Repositories;
using Bookify.Notification;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace Bookify.Controllers;

public class CardEventController : BaseApiController
{

    private readonly IEventStorage _eventStorage;
    private readonly IHubContext<NotificationHub> _hubContext;
    public CardEventController(IEventStorage eventStorage, IHubContext<NotificationHub> hubContext)
    {
        _eventStorage = eventStorage ?? throw new ArgumentNullException(nameof(eventStorage));
        _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(CardEvent), (int)HttpStatusCode.OK)]    
    public async Task<ActionResult<CardEvent>> CreateEventStorage([FromBody]CardEvent cardEvent)
    {
        var cardEventDTO = await _eventStorage.CreateEventStorage(cardEvent);
        if (ReferenceEquals(cardEventDTO, null))
        {
            return BadRequest("Failed to create CardEvent");
        }
        await _hubContext.Clients.All.SendAsync("ReceiveNotification", cardEventDTO);
        
        string json = JsonConvert.SerializeObject(cardEventDTO, Formatting.Indented);
        Console.WriteLine(json);
        
        return Ok(cardEventDTO);
    }
}