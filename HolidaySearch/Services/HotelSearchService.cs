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
}
