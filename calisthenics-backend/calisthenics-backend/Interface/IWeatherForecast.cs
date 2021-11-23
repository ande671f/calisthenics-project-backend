using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Interface
{
	public interface IWeatherForecast
	{
		WeatherForecast CreateWeatherForecast(WeatherForecast weatherForecast);
		WeatherForecast GetWeatherForecast(int id);
	}
}
