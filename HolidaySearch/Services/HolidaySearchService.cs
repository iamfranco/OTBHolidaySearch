using HolidaySearch.Models;

namespace HolidaySearch.Services;
public class HolidaySearchService
{
    private IFlightSearchService _flightSearchService;
    private IHotelSearchService _hotelSearchService;

    public HolidaySearchService(IFlightSearchService flightSearchService, IHotelSearchService hotelSearchService)
    {
        if (flightSearchService is null)
            throw new ArgumentNullException(nameof(flightSearchService));

        if (hotelSearchService is null)
            throw new ArgumentNullException(nameof(hotelSearchService));

        _flightSearchService = flightSearchService;
        _hotelSearchService = hotelSearchService;
    }

    public List<Holiday> Search(string departingFrom, string travelingTo, DateTime departureDate, int duration)
    {
        List<Flight> flights = _flightSearchService.Search(departingFrom, travelingTo, departureDate);
        List<Hotel> hotels = _hotelSearchService.Search(travelingTo, departureDate, duration);

        List<Holiday> holidays = new();

        foreach (Flight flight in flights)
        {
            foreach (Hotel hotel in hotels)
            {
                holidays.Add(new Holiday(flight, hotel));
            }
        }

        return holidays;
    }
}
