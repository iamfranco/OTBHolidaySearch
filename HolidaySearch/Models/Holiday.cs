namespace HolidaySearch.Models;
public class Holiday
{
    private Flight _flight;
    private Hotel _hotel;

    public Holiday(Flight flight, Hotel hotel)
    {
        if (flight is null)
            throw new ArgumentNullException(nameof(flight));

        if (hotel is null)
            throw new ArgumentNullException(nameof(hotel));

        _flight = flight;
        _hotel = hotel;
    }
}
