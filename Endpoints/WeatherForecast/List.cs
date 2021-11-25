namespace api.Endpoints.WeatherForecastEndpoints;

using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

public class Get : EndpointBaseAsync
    .WithoutRequest
    .WithResult<WeatherForecastResult>
{
    string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet("/WeatherForecast")]
    [OpenApiOperation(
        "WeatherForecast.List",
        "List all weather forecasts",
        "List all weather forecasts"
    )]
    [OpenApiTag("WeatherForecastEndpoint")]
    public override async Task<WeatherForecastResult> HandleAsync(
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

        return result;
    }
}
