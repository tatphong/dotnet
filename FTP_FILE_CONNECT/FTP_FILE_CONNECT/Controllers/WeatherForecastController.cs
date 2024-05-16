using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FTP_FILE_CONNECT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("FtpFile")]
        public IActionResult GetFtpFile()
        {
            //WebClient client = new WebClient();
            //client.Credentials = new NetworkCredential("ftp-client", "abc@123");
            //client.DownloadFile("ftp://192.168.66.73/phongTest.pdf", @"phongTest.pdf");
            //return Ok();

            FtpWebRequest request =
            (FtpWebRequest)WebRequest.Create("ftp://192.168.66.73/phongTest.pdf");
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.UseBinary = true;
            request.Credentials = new NetworkCredential("ftp-client", "abc@123");
            request.UsePassive = false;
            request.KeepAlive = false;

            //using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            //using (Stream ftpStream = response.GetResponseStream())
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream ftpStream = response.GetResponseStream();
                return new FileStreamResult(ftpStream, "application/pdf");
            }
        }
    }
}
