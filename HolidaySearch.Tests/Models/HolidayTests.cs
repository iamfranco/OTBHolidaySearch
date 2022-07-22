using HolidaySearch.Models;

namespace HolidaySearch.Tests.Models;
internal class HolidayTests
{
    [Test]
    public void Constructor_With_Null_Flight_Input_Should_Throw_ArgumentNullException()
    {
        // Arrange
        Flight flight = null;
        Hotel hotel = GetHotel();

        // Act
        Holiday holiday;
        Action act = () => holiday = new Holiday(flight, hotel);

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
        Holiday holiday;
        Action act = () => holiday = new Holiday(flight, hotel);

        // Assert
        act.Should().Throw<ArgumentNullException>();
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
