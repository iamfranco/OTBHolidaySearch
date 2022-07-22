using HolidaySearchLibrary.Models;

namespace HolidaySearchLibrary.Services;
public class FlightSearchService : IFlightSearchService
{
    private IReaderService<Flight> _flightReaderService;

    public FlightSearchService(IReaderService<Flight> flightReaderService)
    {
        if (flightReaderService is null)
            throw new ArgumentNullException(nameof(flightReaderService));

        _flightReaderService = flightReaderService;
    }

    public List<Flight> Search(List<string> departingFrom, string travelingTo, DateTime departureDate)
    {
        if (departingFrom is null)
            throw new ArgumentNullException(nameof(departingFrom));

        if (travelingTo is null)
            throw new ArgumentNullException(nameof(travelingTo));

        List<Flight> flights = _flightReaderService.Read();

        return flights.Where(flight =>
            departingFrom.Contains(flight.From) &&
            flight.To == travelingTo &&
            flight.DepartureDate == departureDate).ToList();
    }
}
