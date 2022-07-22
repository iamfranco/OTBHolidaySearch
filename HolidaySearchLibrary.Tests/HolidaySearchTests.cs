using HolidaySearchLibrary.Models;

namespace HolidaySearchLibrary.Tests;
internal class HolidaySearchTests
{
    private HolidaySearch _holidaySearch;

    [Test]
    public void Constructor_With_Null_DepartingFrom_Should_Throw_ArgumentNullException()
    {
        // Arrange
        string departingFrom = null;
        string travelingTo = "AGP";
        DateTime departureDate = DateTime.Parse("2023/07/01");
        int duration = 7;

        // Act
        Action act = () => _holidaySearch = new HolidaySearch(
            departingFrom,
            travelingTo,
            departureDate,
            duration);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_With_Null_TravelingTo_Should_Throw_ArgumentNullException()
    {
        // Arrange
        string departingFrom = "MAN";
        string travelingTo = null;
        DateTime departureDate = DateTime.Parse("2023/07/01");
        int duration = 7;

        // Act
        Action act = () => _holidaySearch = new HolidaySearch(
            departingFrom,
            travelingTo,
            departureDate,
            duration);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_With_Customer_1_Input_Then_Results_First_Should_Return_Correct_Holiday()
    {
        // Arrange
        string departingFrom = "MAN";
        string travelingTo = "AGP";
        DateTime departureDate = DateTime.Parse("2023/07/01");
        int duration = 7;

        Holiday expectedFirstResult = new(
            flight : new()
            {
                Id = 2,
                Airline = "Oceanic Airlines",
                From = "MAN",
                To = "AGP",
                Price = 245,
                DepartureDate = DateTime.Parse("2023-07-01")
            },
            hotel : new()
            {
                Id = 9,
                Name = "Nh Malaga",
                ArrivalDate = DateTime.Parse("2023-07-01"),
                PricePerNight = 83,
                LocalAirports = new List<string>() { "AGP" },
                Nights = 7
            });

        // Act
        _holidaySearch = new HolidaySearch(
            departingFrom,
            travelingTo,
            departureDate,
            duration);

        List<Holiday> results = _holidaySearch.Results;

        // Assert
        results.First().Should().BeEquivalentTo(expectedFirstResult);
    }
}
