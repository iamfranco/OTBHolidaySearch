using HolidaySearch.Models;
using HolidaySearch.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Tests.Services;
internal class HotelSearchServiceTests
{
    Mock<IReaderService<Hotel>> _hotelReaderServiceMock;
    HotelSearchService _hotelSearchService;

    [SetUp]
    public void Setup()
    {
        _hotelReaderServiceMock = new Mock<IReaderService<Hotel>>();
        _hotelSearchService = new HotelSearchService(_hotelReaderServiceMock.Object);
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
}
