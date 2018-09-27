using Microsoft.Extensions.Configuration;

namespace WebApplication1
{
    public interface IGreeter
    {
        string GetMessageOfTheDay();
    }
    public class Greeting:IGreeter
    {
        private IConfiguration _configuration;

        public Greeting(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetMessageOfTheDay()
        {
            return "Greeting of the Day"+_configuration["Greeting"];
        }
    }

}