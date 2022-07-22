using HolidaySearch.Models;

namespace HolidaySearch.Services;
public interface IFlightReaderService
{
    List<Flight> Read();
}