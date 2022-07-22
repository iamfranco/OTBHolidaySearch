namespace HolidaySearchLibrary;
public class HolidaySearch
{
    public HolidaySearch(string departingFrom, string travelingTo, DateTime departureDate, int duration)
    {
        if (departingFrom is null)
            throw new ArgumentNullException(nameof(departingFrom));

        if (travelingTo is null)
            throw new ArgumentNullException(nameof(travelingTo));
    }
}
