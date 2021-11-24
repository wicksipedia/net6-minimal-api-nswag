namespace api.Endpoints.WeatherForecastEndpoints;

public record WeatherForecastRecord(
    DateTime Date,
    int TemperatureC,
    string? Summary
)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}