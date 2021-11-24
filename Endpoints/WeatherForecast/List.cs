// File: sample/SampleEndpointApp/Endpoints/Authors/List.cs
namespace api.Endpoints.WeatherForecastEndpoints;

using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

public class Get : BaseAsyncEndpoint
    .WithoutRequest
    .WithResponse<WeatherForecastResult>
{
    string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet("/WeatherForecast")]
    [SwaggerOperation(
        Summary = "List all weather forecasts",
        Description = "List all weather forecasts",
        OperationId = "WeatherForecast.List",
        Tags = new[] { "WeatherForecastEndpoint" })
    ]
    public override async Task<ActionResult<WeatherForecastResult>> HandleAsync(
        CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        IEnumerable<WeatherForecastRecord> forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecastRecord
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            Summaries[Random.Shared.Next(Summaries.Length)]
        ));

        WeatherForecastResult result = new()
        {
            Forecasts = forecasts.ToList()
        };

        return Ok(result);
    }
}
