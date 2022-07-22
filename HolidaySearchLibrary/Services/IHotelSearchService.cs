using HolidaySearchLibrary.Models;

namespace HolidaySearchLibrary.Services;
public interface IHotelSearchService
{
    List<Hotel> Search(string localAirport, DateTime arrivalDate, int duration);
}