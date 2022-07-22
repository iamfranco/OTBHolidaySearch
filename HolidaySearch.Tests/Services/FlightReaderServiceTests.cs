using HolidaySearch.Services;

namespace HolidaySearch.Tests.Services;
internal class FlightReaderServiceTests
{
    private FlightReaderService _flightReaderService;

    [Test]
    public void Constructor_With_Null_Input_Should_Throw_ArgumentNullException()
    {
        // Arrange
        string filePath = null;

        // Act
        Action act = () => _flightReaderService = new FlightReaderService(filePath);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }
}
