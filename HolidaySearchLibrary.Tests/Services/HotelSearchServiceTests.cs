using HolidaySearchLibrary.Models;
using HolidaySearchLibrary.Services;
using Moq;

namespace HolidaySearchLibrary.Tests.Services;
internal class HotelSearchServiceTests
{
    private Mock<IReaderService<Hotel>> _hotelReaderServiceMock;
    private HotelSearchService _hotelSearchService;

    [SetUp]
    public void Setup()
    {
        _hotelReaderServiceMock = new Mock<IReaderService<Hotel>>();
        _hotelSearchService = new HotelSearchService(_hotelReaderServiceMock.Object);

        _hotelReaderServiceMock.Setup(x => x.Read())
            .Returns(GetHotels());
    }

    [Test]
    public void Constructor_With_Null_Input_Should_Throw_ArgumentNullException()
    {
        // Arrange
        IReaderService<Hotel> hotelReaderService = null;

        // Act
        Action act = () => _hotelSearchService = new HotelSearchService(hotelReaderService);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Search_With_Null_LocalAirport_Should_Throw_ArgumentNullException()
    {
        // Arrange
        string localAirport = null;
        DateTime arrivalDate = DateTime.Parse("2023-01-01");
        int duration = 7;

        // Act
        Action act = () => _hotelSearchService.Search(localAirport, arrivalDate, duration);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Search_Should_Return_List_Of_Hotels_Matching_Parameters()
    {
        // Arrange
        string localAirport = "TFS";
        DateTime arrivalDate = DateTime.Parse("2022-11-05");
        int duration = 7;

        List<Hotel> expectedResult = new()
        {
            GetHotels()[0],
            GetHotels()[1]
        };

        // Act
        List<Hotel> result = _hotelSearchService.Search(localAirport, arrivalDate, duration);

        // Assert
        result.Should().BeEquivalentTo(expectedResult,
            options => options.WithStrictOrdering());
    }

    [Test]
    public void Search_With_Input_Parameters_Not_Matching_Any_Hotel_Should_Return_Empty_List_Of_Hotels()
    {
        // Arrange
        string localAirport = "ABC";
        DateTime arrivalDate = DateTime.Parse("2022-11-05");
        int duration = 7;

        // Act
        List<Hotel> result = _hotelSearchService.Search(localAirport, arrivalDate, duration);

        // Assert
        result.Should().BeOfType(typeof(List<Hotel>));
        result.Count.Should().Be(0);
    }

    private static List<Hotel> GetHotels()
    {
        return new()
        {
            new()
            {
                Id = 1,
                Name = "Iberostar Grand Portals Nous",
                ArrivalDate = DateTime.Parse("2022-11-05"),
                PricePerNight = 100,
                LocalAirports = new List<string>() {"TFS"},
                Nights = 7
            },
            new()
            {
                Id = 2,
                Name = "Laguna Park 2",
                ArrivalDate = DateTime.Parse("2022-11-05"),
                PricePerNight = 50,
                LocalAirports = new List<string>() {"TFS"},
                Nights = 7
            },
            new()
            {
                Id = 3,
                Name = "Sol Katmandu Park & Resort",
                ArrivalDate = DateTime.Parse("2023-06-15"),
                PricePerNight = 59,
                LocalAirports = new List<string>() {"PMI"},
                Nights = 14
            }
        };
    }
}
