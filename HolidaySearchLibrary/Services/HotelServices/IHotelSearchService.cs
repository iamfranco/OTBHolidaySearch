using HolidaySearchLibrary.Models;

namespace HolidaySearchLibrary.Services.HotelServices;
public interface IHotelSearchService
{
    List<Hotel> Search(string localAirport, DateTime arrivalDate, int duration);
}