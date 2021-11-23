using calisthenics_backend.Database;
using calisthenics_backend.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Repository
{
	public class WeatherForecastRepository : IWeatherForecast
	{
		private readonly Context _context;

		public WeatherForecastRepository(Context context)
		{
			_context = context;
		}
		public WeatherForecast CreateWeatherForecast(WeatherForecast weatherForecast)
		{
			_context.WeatherForecasts.Add(weatherForecast);
			_context.SaveChanges();
			return weatherForecast;
		}

		public WeatherForecast GetWeatherForecast(int id)
		{
			return _context.WeatherForecasts.FirstOrDefault(x => x.Id == id);
		}
	}
}
