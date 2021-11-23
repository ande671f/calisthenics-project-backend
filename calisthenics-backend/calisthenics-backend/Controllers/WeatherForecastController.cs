using calisthenics_backend.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly IWeatherForecast _weatherForecast;

		public WeatherForecastController( IWeatherForecast weatherForecast)
		{
			_weatherForecast = weatherForecast;
		}

		[HttpGet]
		public WeatherForecast Get(int id)
		{
			WeatherForecast forecast = _weatherForecast.GetWeatherForecast(id);
			return forecast;
		}


		[HttpPost]
		public void Post()
		{
			var forecast = new WeatherForecast
			{

				Date = DateTime.Now,
				TemperatureC = 37,
				Summary = "Denmark",
			};

			_weatherForecast.CreateWeatherForecast(forecast);
		}
	}
}
