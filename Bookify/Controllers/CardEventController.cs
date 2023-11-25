using System.Net;
using Application.Repositories;
using Bookify.Notification;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

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
        await _eventStorage.CreateEventStorage(cardEvent);
        await _hubContext.Clients.All.SendAsync("ReceiveNotification", cardEvent);
        
        return CreatedAtRoute("GetEventStorage", new { orderType = cardEvent.OrderType}, cardEvent);
    }
}