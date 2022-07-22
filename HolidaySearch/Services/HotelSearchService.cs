using HolidaySearch.Models;

namespace HolidaySearch.Services;
public class HotelSearchService : IHotelSearchService
{
    private IReaderService<Hotel> _hotelReaderService;

    public HotelSearchService(IReaderService<Hotel> hotelReaderService)
    {
        if (hotelReaderService is null)
            throw new ArgumentNullException(nameof(hotelReaderService));

        _hotelReaderService = hotelReaderService;
    }

    public List<Hotel> Search(string localAirport, DateTime arrivalDate, int duration)
    {
        if (localAirport is null)
            throw new ArgumentNullException(nameof(localAirport));

        List<Hotel> hotels = _hotelReaderService.Read();

        return hotels.Where(hotel =>
            hotel.LocalAirports.Contains(localAirport) &&
            hotel.ArrivalDate == arrivalDate &&
            hotel.Nights == duration).ToList();
    }
}
