using HolidaySearch.Models;

namespace HolidaySearch.Services;
public interface IFlightSearchService
{
    List<Flight> Search(string departingFrom, string travelingTo, DateTime departureDate);
}