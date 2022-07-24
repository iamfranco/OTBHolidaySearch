using HolidaySearchLibrary.Models;
using HolidaySearchLibrary.Services.FlightServices;
using HolidaySearchLibrary.Services.HotelServices;

namespace HolidaySearchLibrary.Services;
public class HolidaySearchService
{
    private readonly IFlightSearchService _flightSearchService;
    private readonly IHotelSearchService _hotelSearchService;

    public HolidaySearchService(IFlightSearchService flightSearchService, IHotelSearchService hotelSearchService)
    {
        if (flightSearchService is null)
            throw new ArgumentNullException(nameof(flightSearchService));

        if (hotelSearchService is null)
            throw new ArgumentNullException(nameof(hotelSearchService));

        _flightSearchService = flightSearchService;
        _hotelSearchService = hotelSearchService;
    }

    public List<Holiday> Search(List<string> departingFrom, string travelingTo, DateTime departureDate, int duration)
    {
        if (departingFrom is null)
            throw new ArgumentNullException(nameof(departingFrom));

        if (travelingTo is null)
            throw new ArgumentNullException(nameof(travelingTo));

        List<Flight> flights = _flightSearchService.Search(departingFrom, travelingTo, departureDate);
        List<Hotel> hotels = _hotelSearchService.Search(travelingTo, departureDate, duration);

        List<Holiday> holidays = GetHolidaysFromFlightsAndHotelsCombinations(flights, hotels);

        holidays = holidays.OrderBy(holiday => holiday.TotalPrice).ToList();

        return holidays;
    }

    private static List<Holiday> GetHolidaysFromFlightsAndHotelsCombinations(List<Flight> flights, List<Hotel> hotels)
    {
        List<Holiday> holidays = flights.SelectMany(_ => hotels,
            (flight, hotel) => new Holiday(flight, hotel))
            .ToList();

        return holidays;
    }
}
