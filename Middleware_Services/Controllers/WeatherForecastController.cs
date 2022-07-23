using Microsoft.AspNetCore.Mvc;
using Middleware_Services.Services;

namespace Middleware_Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController(IMessagingService messageService, TelegramService telegramService,
            ILogger<WeatherForecastController> logger,IConfiguration config)
        {
            _messageService = messageService ?? throw new ArgumentException(nameof(messageService));
            _telegramService = telegramService ?? throw new ArgumentException(nameof(telegramService));
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _config = config ?? throw new ArgumentException(nameof(config));
        }

        private readonly IMessagingService _messageService;
        private readonly TelegramService _telegramService;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _config;

        [HttpPost]
        public ActionResult SendMessage()
        {
            _messageService.SendMessage("Hello!");
            _telegramService.SendMessage("Hello world");
            _logger.LogInformation("The messages has been sent at {0}",DateTime.Now);
            return Ok();
        }

        [HttpGet]
        public ActionResult GetMessage()
        {
            string message = _config["Message"];
            return Ok(message);
        }
        
    }
}