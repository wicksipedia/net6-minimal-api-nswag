namespace api.Endpoints.WeatherForecastEndpoints;

public class WeatherForecastResult
{
    public List<WeatherForecastRecord> Forecasts { get; set; } = new();
}
