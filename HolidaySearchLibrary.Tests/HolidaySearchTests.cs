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
    public void Constructor_With_DepartingFrom_One_Airport_Then_Results_First_Should_Return_Correct_Holiday()
    {
        // Arrange
        List<string> departingFrom = new() { "MAN" };
        string travelingTo = "AGP";
        DateTime departureDate = DateTime.Parse("2023/07/01");
        int duration = 7;

        // Act
        _holidaySearch = new HolidaySearch(
            departingFrom,
            travelingTo,
            departureDate,
            duration);

        List<Holiday> results = _holidaySearch.Results;

        // Assert
        results.First().TotalPrice.Should().Be(826);

        results.First().Flight.Id.Should().Be(2);
        results.First().Flight.Airline.Should().Be("Oceanic Airlines");
        results.First().Flight.DepartingFrom.Should().Be("MAN");
        results.First().Flight.TravelingTo.Should().Be("AGP");
        results.First().Flight.Price.Should().Be(245);
        results.First().Flight.DepartureDate.Should().Be(DateTime.Parse("2023-07-01"));

        results.First().Hotel.Id.Should().Be(9);
        results.First().Hotel.Name.Should().Be("Nh Malaga");
        results.First().Hotel.ArrivalDate.Should().Be(DateTime.Parse("2023-07-01"));
        results.First().Hotel.PricePerNight.Should().Be(83);
        results.First().Hotel.LocalAirports.Should().BeEquivalentTo(new List<string>() { "AGP" });
        results.First().Hotel.Nights.Should().Be(7);
    }

    [Test]
    public void Constructor_With_DepartingFrom_Any_London_Airports_Then_Results_First_Should_Return_Correct_Holiday()
    {
        // Arrange
        List<string> departingFrom = new List<string>() { "LCY", "LHR", "LGW", "LTN", "STN", "SEN" };
        string travelingTo = "PMI";
        DateTime departureDate = DateTime.Parse("2023/06/15");
        int duration = 10;

        // Act
        _holidaySearch = new HolidaySearch(
            departingFrom,
            travelingTo,
            departureDate,
            duration);

        List<Holiday> results = _holidaySearch.Results;

        // Assert
        results.First().TotalPrice.Should().Be(675);

        results.First().Flight.Id.Should().Be(6);
        results.First().Flight.Airline.Should().Be("Fresh Airways");
        results.First().Flight.DepartingFrom.Should().Be("LGW");
        results.First().Flight.TravelingTo.Should().Be("PMI");
        results.First().Flight.Price.Should().Be(75);
        results.First().Flight.DepartureDate.Should().Be(DateTime.Parse("2023-06-15"));

        results.First().Hotel.Id.Should().Be(5);
        results.First().Hotel.Name.Should().Be("Sol Katmandu Park & Resort");
        results.First().Hotel.ArrivalDate.Should().Be(DateTime.Parse("2023-06-15"));
        results.First().Hotel.PricePerNight.Should().Be(60);
        results.First().Hotel.LocalAirports.Should().BeEquivalentTo(new List<string>() { "PMI" });
        results.First().Hotel.Nights.Should().Be(10);
    }

    [Test]
    public void Constructor_With_DepartingFrom_Any_Airport_Input_Then_Results_First_Should_Return_Correct_Holiday()
    {
        // Arrange
        List<string> departingFrom = new List<string>();
        string travelingTo = "LPA";
        DateTime departureDate = DateTime.Parse("2022/11/10");
        int duration = 14;

        // Act
        _holidaySearch = new HolidaySearch(
            departingFrom,
            travelingTo,
            departureDate,
            duration);

        List<Holiday> results = _holidaySearch.Results;

        // Assert
        results.First().TotalPrice.Should().Be(1175);

        results.First().Flight.Id.Should().Be(7);
        results.First().Flight.Airline.Should().Be("Trans American Airlines");
        results.First().Flight.DepartingFrom.Should().Be("MAN");
        results.First().Flight.TravelingTo.Should().Be("LPA");
        results.First().Flight.Price.Should().Be(125);
        results.First().Flight.DepartureDate.Should().Be(DateTime.Parse("2022-11-10"));

        results.First().Hotel.Id.Should().Be(6);
        results.First().Hotel.Name.Should().Be("Club Maspalomas Suites and Spa");
        results.First().Hotel.ArrivalDate.Should().Be(DateTime.Parse("2022-11-10"));
        results.First().Hotel.PricePerNight.Should().Be(75);
        results.First().Hotel.LocalAirports.Should().BeEquivalentTo(new List<string>() { "LPA" });
        results.First().Hotel.Nights.Should().Be(14);
    }
}
