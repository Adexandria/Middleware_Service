namespace Middleware_Services.Services
{
    public class WhatsappService : TelegramService
    {
        public override void SendMessage(string message)
        {
            Console.WriteLine("I'm sending " + message + " via whatsapp.");
        }

    }
}
