using HolidaySearch.Models;
using HolidaySearch.Services;
using Moq;

namespace HolidaySearch.Tests.Services;
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
    public void Search_Should_Return_List_Of_Flights_Matching_Parameters()
    {
        // Arrange
        string departingFrom = "MAN";
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
    public void Search_With_DepartingFrom_Null_Should_Throw_ArgumentNullException()
    {
        // Arrange
        string departingFrom = null;
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
        string departingFrom = "MAN";
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
        string departingFrom = "ABC";
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
                From = "MAN",
                To = "TFS",
                Price = 470,
                DepartureDate = DateTime.Parse("2023-07-01")
            },
            new()
            {
                Id = 2,
                Airline = "Oceanic Airlines",
                From = "MAN",
                To = "AGP",
                Price = 245,
                DepartureDate = DateTime.Parse("2023-07-01")
            },
            new()
            {
                Id = 3,
                Airline = "Trans American Airlines",
                From = "MAN",
                To = "PMI",
                Price = 170,
                DepartureDate = DateTime.Parse("2023-06-15")
            },
            new()
            {
                Id = 4,
                Airline = "Trans American Airlines",
                From = "AGP",
                To = "PMI",
                Price = 240,
                DepartureDate = DateTime.Parse("2023-06-15")
            }
        };
    }
}
