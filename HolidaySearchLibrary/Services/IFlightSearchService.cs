using HolidaySearchLibrary.Models;

namespace HolidaySearchLibrary.Services;
public interface IFlightSearchService
{
    List<Flight> Search(List<string> departingFrom, string travelingTo, DateTime departureDate);
}