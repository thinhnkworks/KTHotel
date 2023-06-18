using System.Threading.Tasks;

namespace KTHotel.Api.Clients
{
    public interface IWeatherStackClient
    {
        Task<WeatherStackResponse> GetCurrentWeather(string city);
    }
}