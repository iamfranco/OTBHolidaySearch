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

    public List<Flight> Search(string departingFrom, string travelingTo, DateTime departureDate)
    {
        if (departingFrom is null)
            throw new ArgumentNullException(nameof(departingFrom));

        if (travelingTo is null)
            throw new ArgumentNullException(nameof(travelingTo));

        List<Flight> flights = _flightReaderService.Read();

        return flights.Where(flight =>
            flight.From == departingFrom &&
            flight.To == travelingTo &&
            flight.DepartureDate == departureDate).ToList();
    }
}
