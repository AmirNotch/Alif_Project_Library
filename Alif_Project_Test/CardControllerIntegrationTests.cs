using System.Net;
using System.Text;
using Entity;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace Alif_Project_Test;

[Collection("IntegrationTests")]
public class CardControllerIntegrationTests
{
    private readonly HttpClient _client;

    public CardControllerIntegrationTests(HttpClient client)
    {
        _client = client;
    }
    
    [Fact]
    public async Task PostCardEvent_ReturnsSuccessStatusCode()
    {
        // Arrange
        var cardEvent = new CardEvent
        {
            SessionId = new Guid("29827525-06c9-4b1e-9d9b-7c4584e82f56"),
            OrderType = "Purchase",
            Card = "4433**1409",
            EventDate = new DateTime(2023, 11, 10),
            WebsiteUrl = "https://amazon.com"
        };

        var content = new StringContent(JsonConvert.SerializeObject(cardEvent), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/CardEvent", content);

        // Assert
        response.EnsureSuccessStatusCode(); // 200-299 статус коды считаются успешными

        // Дополнительные проверки, если необходимо
    }

    [Fact]
    public async Task PostCardEvent_WithInvalidData_ReturnsBadRequest()
    {
        // Arrange
        var invalidCardEvent = new CardEvent(); // Не заполняем обязательные поля, чтобы вызвать ошибку валидации

        var content = new StringContent(JsonConvert.SerializeObject(invalidCardEvent), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/CardEvent", content);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        // Дополнительные проверки, если необходимо
    }
}