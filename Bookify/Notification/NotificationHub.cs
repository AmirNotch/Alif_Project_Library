using Microsoft.AspNetCore.SignalR;

namespace Bookify.Notification;

public class NotificationHub : Hub
{
    public static event Action<string> OnNotification;
    
    public void SendNotificationToAll(string message)
    {
        // Отправка уведомления всем подключенным клиентам
        Clients.All.SendAsync("ReceiveNotification", message);

        // Вывод уведомления в терминал (или куда-либо еще)
        Console.WriteLine($"Notification sent to all: {message}");
    }

}