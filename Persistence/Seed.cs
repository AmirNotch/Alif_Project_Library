using Entity;

namespace Persistence;

public class Seed
{
    public static async Task SeedData(DataContext context)
    {
        if (context.CardEvents.Any())
        {
            var cardEvents = new List<CardEvent>
            {
                new CardEvent
                {
                    SessionId = new Guid("29827525-06c9-4b1e-9d9b-7c4584e82f23"),
                    OrderType = "SendOtp",
                    Card = "4433**1409",
                    EventDate = new DateTime(2023, 11, 10),
                    WebsiteUrl = "https://adidas.com"
                },
                new CardEvent
                {
                    SessionId = new Guid("500cf308-e666-4639-aa9f-f6376015d1b0"),
                    OrderType = "CardVerify",
                    Card = "4433**1409",
                    EventDate = new DateTime(2021, 10, 23),
                    WebsiteUrl = "https://somon.tj"
                }
            };
            
            await context.CardEvents.AddRangeAsync(cardEvents);
            await context.SaveChangesAsync();
        }
    }
}