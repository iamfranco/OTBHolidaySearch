using HolidaySearch.Models;
using HolidaySearch.Services;
using Moq;

namespace HolidaySearch.Tests.Services;
internal class FlightSearchServiceTests
{
    private FlightSearchService _flightSearchService;
    private Mock<IFlightReaderService> _flightReaderServiceMock;

    [SetUp]
    public void Setup()
    {
        // Arrange
        _flightReaderServiceMock = new Mock<IFlightReaderService>();
        _flightSearchService = new FlightSearchService(_flightReaderServiceMock.Object);

        _flightReaderServiceMock.Setup(x => x.Read())
            .Returns(GetFlights());
    }

    [Test]
    public void Constructor_With_Null_Input_Should_Throw_ArgumentNullException()
    {
        // Arrange
        IFlightReaderService flightReaderService = null;

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
    public void Search_With_DepartingFrom_Null_Should_Return_List_Of_Flights_Matching_All_Non_Null_Parameters()
    {
        // Arrange
        string departingFrom = null;
        string travelingTo = "PMI";
        DateTime departureDate = DateTime.Parse("2023-06-15");

        List<Flight> expectedResult = new()
        {
            GetFlights()[2],
            GetFlights()[3],
        };

        // Act
        List<Flight> result = _flightSearchService.Search(departingFrom, travelingTo, departureDate);

        // Assert
        result.Should().BeEquivalentTo(expectedResult,
            options => options.WithStrictOrdering());
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
