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
}
