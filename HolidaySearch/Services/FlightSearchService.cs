using HolidaySearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Services;
public class FlightSearchService
{
    private IFlightReaderService _flightReaderService;

    public FlightSearchService(IFlightReaderService flightReaderService)
    {
        if (flightReaderService is null)
            throw new ArgumentNullException(nameof(flightReaderService));

        _flightReaderService = flightReaderService;
    }

    public List<Flight> Search(string departingFrom, string travelingTo, DateTime departureDate)
    {
        List<Flight> flights = _flightReaderService.Read();

        return flights.Where(flight =>
            (departingFrom is null || flight.From == departingFrom) &&
            (travelingTo is null || flight.To == travelingTo) &&
            flight.DepartureDate == departureDate).ToList();
    }
}
