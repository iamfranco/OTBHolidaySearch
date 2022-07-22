using HolidaySearch.Models;

namespace HolidaySearch.Services;
public class HotelSearchService
{
    private IReaderService<Hotel> _hotelReaderService;

    public HotelSearchService(IReaderService<Hotel> hotelReaderService)
    {
        _hotelReaderService = hotelReaderService;
    }
}
