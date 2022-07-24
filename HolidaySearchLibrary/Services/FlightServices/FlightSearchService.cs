using HolidaySearchLibrary.Models;
using HolidaySearchLibrary.Services.ReaderServices;

namespace HolidaySearchLibrary.Services.FlightServices;
public class FlightSearchService : IFlightSearchService
{
    private readonly IReaderService<Flight> _flightReaderService;

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
            IsDepartingFromMatching(flight, departingFrom) &&
            IsTravelingToMatching(flight, travelingTo) &&
            IsDepartureDateMatching(flight, departureDate)
            ).ToList();
    }

    private static bool IsDepartingFromMatching(Flight flight, List<string> departingFrom)
    {
        if (!departingFrom.Any())
            return true;

        return departingFrom.Contains(flight.DepartingFrom);
    }

    private static bool IsTravelingToMatching(Flight flight, string travelingTo) => 
        flight.TravelingTo == travelingTo;

    private static bool IsDepartureDateMatching(Flight flight, DateTime departureDate) => 
        flight.DepartureDate == departureDate;
}
