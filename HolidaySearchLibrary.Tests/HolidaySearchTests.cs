using HolidaySearchLibrary.Models;

namespace HolidaySearchLibrary.Tests;
internal class HolidaySearchTests
{
    private HolidaySearch _holidaySearch;

    [Test]
    public void Constructor_With_Null_DepartingFrom_Should_Throw_ArgumentNullException()
    {
        // Arrange
        List<string> departingFrom = null;
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
        List<string> departingFrom = new() { "MAN" };
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
        List<string> departingFrom = new() { "MAN" };
        string travelingTo = "AGP";
        DateTime departureDate = DateTime.Parse("2023/07/01");
        int duration = 7;

        Holiday expectedFirstResult = new(
            flight : new()
            {
                Id = 2,
                Airline = "Oceanic Airlines",
                DepartingFrom = "MAN",
                TravelingTo = "AGP",
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
        results.First().TotalPrice.Should().Be(826);
    }

    [Test]
    public void Constructor_With_Customer_2_Input_Then_Results_First_Should_Return_Correct_Holiday()
    {
        // Arrange
        List<string> departingFrom = new List<string>() { "LCY", "LHR", "LGW", "LTN", "STN", "SEN" };
        string travelingTo = "PMI";
        DateTime departureDate = DateTime.Parse("2023/06/15");
        int duration = 10;

        Holiday expectedFirstResult = new(
            flight: new()
            {
                Id = 6,
                Airline = "Fresh Airways",
                DepartingFrom = "LGW",
                TravelingTo = "PMI",
                Price = 75,
                DepartureDate = DateTime.Parse("2023-06-15")
            },
            hotel: new()
            {
                Id = 5,
                Name = "Sol Katmandu Park & Resort",
                ArrivalDate = DateTime.Parse("2023-06-15"),
                PricePerNight = 60,
                LocalAirports = new List<string>() { "PMI" },
                Nights = 10
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
        results.First().TotalPrice.Should().Be(675);
    }

    [Test]
    public void Constructor_With_Customer_3_Input_Then_Results_First_Should_Return_Correct_Holiday()
    {
        // Arrange
        List<string> departingFrom = new List<string>();
        string travelingTo = "LPA";
        DateTime departureDate = DateTime.Parse("2022/11/10");
        int duration = 14;

        Holiday expectedFirstResult = new(
            flight: new()
            {
                Id = 7,
                Airline = "Trans American Airlines",
                DepartingFrom = "MAN",
                TravelingTo = "LPA",
                Price = 125,
                DepartureDate = DateTime.Parse("2022-11-10")
            },
            hotel: new()
            {
                Id = 6,
                Name = "Club Maspalomas Suites and Spa",
                ArrivalDate = DateTime.Parse("2022-11-10"),
                PricePerNight = 75,
                LocalAirports = new List<string>() { "LPA" },
                Nights = 14
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
        results.First().TotalPrice.Should().Be(1175);
    }
}
