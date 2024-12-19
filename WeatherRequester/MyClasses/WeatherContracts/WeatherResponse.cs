using System.Net;

namespace MyClasses.WeatherContracts;
public class WeatherResponse
{
    public HttpStatusCode StatusCode { get; init; }
    public required string ResponseMessage { get; init; }
    public required string Temperature { get; init; }
    public required string Humidity { get; init; }
}

