namespace HolidaySearch.Services;
public class HolidaySearchService
{
    private IFlightSearchService _flightSearchService;
    private IHotelSearchService _hotelSearchService;

    public HolidaySearchService(IFlightSearchService flightSearchService, IHotelSearchService hotelSearchService)
    {
        _flightSearchService = flightSearchService;
        _hotelSearchService = hotelSearchService;
    }
}
