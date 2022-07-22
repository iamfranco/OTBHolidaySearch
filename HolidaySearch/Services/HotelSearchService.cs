using HolidaySearch.Models;

namespace HolidaySearch.Services;
public class HotelSearchService
{
    private IReaderService<Hotel> _hotelReaderService;

    public HotelSearchService(IReaderService<Hotel> hotelReaderService)
    {
        if (hotelReaderService is null)
            throw new ArgumentNullException(nameof(hotelReaderService));

        _hotelReaderService = hotelReaderService;
    }

    public void Search(string localAirport, DateTime arrivalDate, int duration)
    {
        if (localAirport is null)
            throw new ArgumentNullException(nameof(localAirport));

        throw new NotImplementedException();
    }
}
