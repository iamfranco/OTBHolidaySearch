using HolidaySearch.Services;
using Moq;

namespace HolidaySearch.Tests.Services;
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
}
