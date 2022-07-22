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
}
