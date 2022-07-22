using HolidaySearchLibrary.Models;
using HolidaySearchLibrary.Services;
using Moq;

namespace HolidaySearchLibrary.Tests.Services;
internal class HolidaySearchServiceTests
{
    private Mock<IFlightSearchService> _flightSearchServiceMock;
    private Mock<IHotelSearchService> _hotelSearchServiceMock;
    private HolidaySearchService _holidaySearchService;

    [SetUp]
    public void Setup()
    {
        // Arrange
        _flightSearchServiceMock = new Mock<IFlightSearchService>();
        _hotelSearchServiceMock = new Mock<IHotelSearchService>();

        _holidaySearchService = new HolidaySearchService(_flightSearchServiceMock.Object,
            _hotelSearchServiceMock.Object);
    }

    [Test]
    public void Constructor_With_FlightSearchService_Null_Input_Should_Throw_ArgumentNullException()
    {
        // Act
        Action act = () => _holidaySearchService = new HolidaySearchService(null,
            _hotelSearchServiceMock.Object);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_With_HotelSearchService_Null_Input_Should_Throw_ArgumentNullException()
    {
        // Act
        Action act = () => _holidaySearchService = new HolidaySearchService(_flightSearchServiceMock.Object,
            null);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Search_With_Null_DepartingFrom_Input_Should_Throw_ArgumentNullException()
    {
        // Arrange
        List<string> departingFrom = null;
        string travelingTo = "AGP";
        DateTime departureDate = DateTime.Parse("2023-07-01");
        int duration = 7;

        // Act
        Action act = () => _holidaySearchService.Search(departingFrom, travelingTo, departureDate, duration);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Search_With_Null_TravelingTo_Input_Should_Throw_ArgumentNullException()
    {
        // Arrange
        List<string> departingFrom = new() { "MAN" };
        string travelingTo = null;
        DateTime departureDate = DateTime.Parse("2023-07-01");
        int duration = 7;

        // Act
        Action act = () => _holidaySearchService.Search(departingFrom, travelingTo, departureDate, duration);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Search_Should_Return_List_Of_Holidays_For_Each_Combination_Of_Flight_And_Hotel()
    {
        // Arrange
        List<string> departingFrom = new() { "MAN" };
        string travelingTo = "AGP";
        DateTime departureDate = DateTime.Parse("2023-07-01");
        int duration = 7;

        _flightSearchServiceMock.Setup(x => x.Search(departingFrom, travelingTo, departureDate))
            .Returns(GetFlights());

        _hotelSearchServiceMock.Setup(x => x.Search(travelingTo, departureDate, duration))
            .Returns(GetHotels());

        List<Holiday> expectedResult = GetHolidayCombinations();

        // Act
        List<Holiday> result = _holidaySearchService.Search(departingFrom, travelingTo, departureDate, duration);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public void Search_Should_Return_Holidays_Ordered_By_TotalPrice_Ascending()
    {
        // Arrange
        List<string> departingFrom = new() { "MAN" };
        string travelingTo = "AGP";
        DateTime departureDate = DateTime.Parse("2023-07-01");
        int duration = 7;

        _flightSearchServiceMock.Setup(x => x.Search(departingFrom, travelingTo, departureDate))
            .Returns(GetFlights());

        _hotelSearchServiceMock.Setup(x => x.Search(travelingTo, departureDate, duration))
            .Returns(GetHotels());

        List<Holiday> expectedResult = GetHolidayCombinations()
            .OrderBy(holiday => holiday.TotalPrice)
            .ToList();

        // Act
        List<Holiday> result = _holidaySearchService.Search(departingFrom, travelingTo, departureDate, duration);

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
                To = "AGP",
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
            }
        };
    }

    private static List<Hotel> GetHotels()
    {
        return new()
        {
            new()
            {
                Id = 1,
                Name = "Iberostar Grand Portals Nous",
                ArrivalDate = DateTime.Parse("2023-07-01"),
                PricePerNight = 100,
                LocalAirports = new List<string>() {"AGP"},
                Nights = 7
            },
            new()
            {
                Id = 2,
                Name = "Laguna Park 2",
                ArrivalDate = DateTime.Parse("2023-07-01"),
                PricePerNight = 50,
                LocalAirports = new List<string>() {"AGP"},
                Nights = 7
            }
        };
    }

    private static List<Holiday> GetHolidayCombinations()
    {
        List<Holiday> holidayCombinations = new();

        foreach (Flight flight in GetFlights())
        {
            foreach (Hotel hotel in GetHotels())
            {
                Holiday holiday = new Holiday(flight, hotel);
                holidayCombinations.Add(holiday);
            }
        }

        return holidayCombinations;
    }
}
