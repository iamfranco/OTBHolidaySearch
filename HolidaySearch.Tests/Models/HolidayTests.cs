using HolidaySearch.Models;

namespace HolidaySearch.Tests.Models;
internal class HolidayTests
{
    private Flight _flight;
    private Hotel _hotel;
    private Holiday _holiday;

    [SetUp]
    public void Setup()
    {
        // Arrange
        _flight = GetFlight();
        _hotel = GetHotel();
        _holiday = new Holiday(_flight, _hotel);
    }

    [Test]
    public void Constructor_With_Null_Flight_Input_Should_Throw_ArgumentNullException()
    {
        // Arrange
        Flight flight = null;
        Hotel hotel = GetHotel();

        // Act
        Action act = () => _holiday = new Holiday(flight, hotel);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_With_Null_Hotel_Input_Should_Throw_ArgumentNullException()
    {
        // Arrange
        Flight flight = GetFlight();
        Hotel hotel = null;

        // Act
        Action act = () => _holiday = new Holiday(flight, hotel);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Flight_Should_Return_Constructor_Input_Flight()
    {
        // Act
        Flight result = _holiday.Flight;

        // Act
        result.Should().BeEquivalentTo(_flight);
    }

    [Test]
    public void Hotel_Should_Return_Constructor_Input_Hotel()
    {
        // Act
        Hotel result = _holiday.Hotel;

        // Act
        result.Should().BeEquivalentTo(_hotel);
    }

    private Flight GetFlight()
    {
        return new()
        {
            Id = 1,
            Airline = "First Class Air",
            From = "MAN",
            To = "TFS",
            Price = 470,
            DepartureDate = DateTime.Parse("2023-07-01")
        };
    }

    private Hotel GetHotel()
    {
        return new()
        {
            Id = 1,
            Name = "Iberostar Grand Portals Nous",
            ArrivalDate = DateTime.Parse("2022-11-05"),
            PricePerNight = 100,
            LocalAirports = new List<string>() { "TFS" },
            Nights = 7
        };
    }
}
