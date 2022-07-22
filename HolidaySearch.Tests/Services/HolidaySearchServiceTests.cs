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
}
