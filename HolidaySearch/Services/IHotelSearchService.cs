using HolidaySearch.Models;

namespace HolidaySearch.Services;
public interface IHotelSearchService
{
    List<Hotel> Search(string localAirport, DateTime arrivalDate, int duration);
}