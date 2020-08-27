using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Preview8Repro.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Preview8Repro.Server.Controllers
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

		// The Web API will only accept tokens 1) for users, and 2) having the access_as_user scope for this API
		static readonly string[] scopeRequiredByApi = new string[] { "user_impersonation" };

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			var rng = new Random();

			_logger.LogWarning("Hope it's not too hot!");

			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}
