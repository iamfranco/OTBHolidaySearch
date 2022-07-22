namespace HolidaySearch.Models;
public class Holiday
{
    public Flight Flight { get; }
    public Hotel Hotel { get; }

    public Holiday(Flight flight, Hotel hotel)
    {
        if (flight is null)
            throw new ArgumentNullException(nameof(flight));

        if (hotel is null)
            throw new ArgumentNullException(nameof(hotel));

        Flight = flight;
        Hotel = hotel;
    }
}
