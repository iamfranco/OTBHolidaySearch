using HolidaySearchLibrary.Models;
using HolidaySearchLibrary.Services;
using Moq;

namespace HolidaySearchLibrary.Tests.Services;
internal class FlightSearchServiceTests
{
    private FlightSearchService _flightSearchService;
    private Mock<IReaderService<Flight>> _flightReaderServiceMock;

    [SetUp]
    public void Setup()
    {
        // Arrange
        _flightReaderServiceMock = new Mock<IReaderService<Flight>>();
        _flightSearchService = new FlightSearchService(_flightReaderServiceMock.Object);

        _flightReaderServiceMock.Setup(x => x.Read())
            .Returns(GetFlights());
    }

    [Test]
    public void Constructor_With_Null_Input_Should_Throw_ArgumentNullException()
    {
        // Arrange
        IReaderService<Flight> flightReaderService = null;

        // Act
        Action act = () => _flightSearchService = new FlightSearchService(flightReaderService);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Search_With_DepartingFrom_One_Airport_Should_Return_List_Of_Flights_Matching_Parameters()
    {
        // Arrange
        List<string> departingFrom = new() { "MAN" };
        string travelingTo = "AGP";
        DateTime departureDate = DateTime.Parse("2023-07-01");

        List<Flight> expectedResult = new()
        {
            GetFlights()[1]
        };

        // Act
        List<Flight> result = _flightSearchService.Search(departingFrom, travelingTo, departureDate);

        // Assert
        result.Should().BeEquivalentTo(expectedResult,
            options => options.WithStrictOrdering());
    }

    [Test]
    public void Search_With_DepartingFrom_Multiple_Airports_Should_Return_List_Of_Flights_Matching_Parameters()
    {
        // Arrange
        List<string> departingFrom = new() { "MAN", "AGP" };
        string travelingTo = "PMI";
        DateTime departureDate = DateTime.Parse("2023-06-15");

        List<Flight> expectedResult = new()
        {
            GetFlights()[2], GetFlights()[3]
        };

        // Act
        List<Flight> result = _flightSearchService.Search(departingFrom, travelingTo, departureDate);

        // Assert
        result.Should().BeEquivalentTo(expectedResult,
            options => options.WithStrictOrdering());
    }

    [Test]
    public void Search_With_DepartingFrom_Empty_Should_Return_List_Of_Flights_Matching_Any_Departure_Airport()
    {
        // Arrange
        List<string> departingFrom = new();
        string travelingTo = "PMI";
        DateTime departureDate = DateTime.Parse("2023-06-15");

        List<Flight> flights = GetFlights();
        List<Flight> expectedResult = new()
        {
            flights[2], flights[3], flights[4]
        };

        // Act
        List<Flight> result = _flightSearchService.Search(departingFrom, travelingTo, departureDate);

        // Assert
        result.Should().BeEquivalentTo(expectedResult,
            options => options.WithStrictOrdering());
    }

    [Test]
    public void Search_With_DepartingFrom_Null_Should_Throw_ArgumentNullException()
    {
        // Arrange
        List<string> departingFrom = null;
        string travelingTo = "PMI";
        DateTime departureDate = DateTime.Parse("2023-06-15");

        // Act
        Action act = () => _flightSearchService.Search(departingFrom, travelingTo, departureDate);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Search_With_TravelingTo_Null_Should_Throw_ArgumentNullException()
    {
        // Arrange
        List<string> departingFrom = new() { "MAN" };
        string travelingTo = null;
        DateTime departureDate = DateTime.Parse("2023-07-01");

        // Act
        Action act = () => _flightSearchService.Search(departingFrom, travelingTo, departureDate);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Search_With_Input_Parameters_Not_Matching_Any_Flights_Should_Return_Empty_List_Of_Flights()
    {
        // Arrange
        List<string> departingFrom = new() { "ABC" };
        string travelingTo = "DEF";
        DateTime departureDate = DateTime.Parse("2023-07-01");

        // Act
        List<Flight> result = _flightSearchService.Search(departingFrom, travelingTo, departureDate);

        // Assert
        result.Should().BeOfType(typeof(List<Flight>));
        result.Count.Should().Be(0);
    }

    private static List<Flight> GetFlights()
    {
        return new()
        {
            new()
            {
                Id = 1,
                Airline = "First Class Air",
                DepartingFrom = "MAN",
                TravelingTo = "TFS",
                Price = 470,
                DepartureDate = DateTime.Parse("2023-07-01")
            },
            new()
            {
                Id = 2,
                Airline = "Oceanic Airlines",
                DepartingFrom = "MAN",
                TravelingTo = "AGP",
                Price = 245,
                DepartureDate = DateTime.Parse("2023-07-01")
            },
            new()
            {
                Id = 3,
                Airline = "Trans American Airlines",
                DepartingFrom = "MAN",
                TravelingTo = "PMI",
                Price = 170,
                DepartureDate = DateTime.Parse("2023-06-15")
            },
            new()
            {
                Id = 4,
                Airline = "Trans American Airlines",
                DepartingFrom = "AGP",
                TravelingTo = "PMI",
                Price = 240,
                DepartureDate = DateTime.Parse("2023-06-15")
            },
            new()
            {
                Id = 5,
                Airline = "Trans American Airlines",
                DepartingFrom = "TFS",
                TravelingTo = "PMI",
                Price = 200,
                DepartureDate = DateTime.Parse("2023-06-15")
            }
        };
    }
}
