
namespace Tilde.MT.TranslationSystemService.Models.Configuration.ServicesConfiguration
{
    public class RabbitMQ
    {
        public string Host { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; } = 5672;
    }
}
