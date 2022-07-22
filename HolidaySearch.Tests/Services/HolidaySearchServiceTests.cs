using HolidaySearch.Services;

namespace HolidaySearch.Tests.Services;
internal class HolidaySearchServiceTests
{
    HolidaySearchService _holidaySearchService;

    [SetUp]
    public void Setup()
    {
        // Arrange
        _holidaySearchService = new HolidaySearchService();
    }
}
