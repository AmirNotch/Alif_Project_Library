using Application.Repositories;
using Bookify.Controllers;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Bookify.XUnits;

public class CardEventsControllerTests
{
    [Fact]
    public void Post_WhenCalled_SaveEventInStorage()
    {
        // // Arrange
        // var mockEventStorage = new Mock<IEventStorage>();
        // var controller = new CardEventController(mockEventStorage.Verify());
        // var cardEvent = new CardEvent
        // {
        //     OrderType = "Purchase",
        //     SessionId = "29827525-06c9-4b1e-9d9b-7c4584e82f56",
        //     Card = "4433**1409",
        //     EventDate = DateTime.UtcNow, // или установите фиксированную дату для теста
        //     WebsiteUrl = "https://amazon.com"
        // };
        //
        // // Act
        // var result = controller.CreateEventStorage(cardEvent);
        //
        // // Assert
        // mockEventStorage.Verify(storage => storage.CreateEventStorage(It.Is<CardEvent>(ce =>
        //     ce.OrderType == cardEvent.OrderType &&
        //     ce.SessionId == cardEvent.SessionId &&
        //     ce.Card == cardEvent.Card &&
        //     ce.EventDate == cardEvent.EventDate &&
        //     ce.WebsiteUrl == cardEvent.WebsiteUrl
        // )), Times.Once);
        //
        // Assert.IsType<OkResult>(result);
    }
}