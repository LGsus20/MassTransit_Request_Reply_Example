using MassTransit;
using MyClasses.WeatherContracts;
using System.Net;

namespace WeatherAPI.Consumers;
public class WeatherConsumer : IConsumer<CheckWeatherCountry>
{
    public async Task Consume(ConsumeContext<CheckWeatherCountry> context)
    {
        string myCountry = context.Message.Country;
        try
        {
            if (myCountry == null)
                await context.RespondAsync<WeatherResponse>(new
                {
                    StatusCode = HttpStatusCode.NotFound,
                    ResponseMessage = "Weather forecast for " + myCountry,
                    Temperature = "",
                    Humidity = "",
                });
            else
                await context.RespondAsync<WeatherResponse>(new
                {
                    StatusCode = HttpStatusCode.OK,
                    ResponseMessage = "Weather forecast for " + myCountry,
                    Temperature = "25°C",
                    Humidity = "50%",
                });
        }
        catch (Exception)
        {
            throw new InvalidOperationException("This is an error TEST\"");
        }
    }
}

