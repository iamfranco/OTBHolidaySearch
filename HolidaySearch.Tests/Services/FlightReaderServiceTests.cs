using HolidaySearch.Models;
using HolidaySearch.Services;

namespace HolidaySearch.Tests.Services;
internal class FlightReaderServiceTests
{
    private ReaderService<Flight> _flightReaderService;

    [Test]
    public void Constructor_With_Null_Input_Should_Throw_ArgumentNullException()
    {
        // Arrange
        string filePath = null;

        // Act
        Action act = () => _flightReaderService = new ReaderService<Flight>(filePath);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Read_Should_Return_List_Of_Flights_Matching_FilePath_Json_Content()
    {
        // Arrange
        string filePath = Directory.GetCurrentDirectory() + @"\Services\TestDataFiles\TestFlightData.json";
        _flightReaderService = new ReaderService<Flight>(filePath);
        List<Flight> expectedResult = GetFlightsForTestFlightDataFile();

        // Act
        List<Flight> result = _flightReaderService.Read();

        // Assert
        result.Should().BeEquivalentTo(expectedResult,
            options => options.WithStrictOrdering());
    }

    [Test]
    public void Read_When_FilePath_File_Does_Not_Exist_Should_Throw_FileNotFoundException()
    {
        // Arrange
        string filePath = Directory.GetCurrentDirectory() + @"NonExistentFile.json";
        _flightReaderService = new ReaderService<Flight>(filePath);

        // Act
        Action act = () => _flightReaderService.Read();

        // Assert
        act.Should().Throw<FileNotFoundException>();
    }

    private static List<Flight> GetFlightsForTestFlightDataFile()
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
            }
        };
    }
}
