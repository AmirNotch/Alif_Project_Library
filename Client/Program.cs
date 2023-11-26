using Client;

public class Program
{
    static void Main(string[] args)
    {
        var notificationClient = new NotificationClient("http://localhost:5048/notificationHub");

        // Подключение к серверу
        notificationClient.Start();

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();

        // Отключение от сервера перед выходом
        notificationClient.Stop();
    }
}