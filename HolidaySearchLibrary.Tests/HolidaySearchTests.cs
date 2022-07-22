namespace HolidaySearchLibrary.Tests;
internal class HolidaySearchTests
{
    private HolidaySearch _holidaySearch;

    [Test]
    public void Constructor_With_Null_DepartingFrom_Should_Throw_ArgumentNullException()
    {
        // Arrange
        string departingFrom = null;
        string travelingTo = "AGP";
        DateTime departureDate = DateTime.Parse("2023/07/01");
        int duration = 7;

        // Act
        Action act = () => _holidaySearch = new HolidaySearch(
            departingFrom,
            travelingTo,
            departureDate,
            duration);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_With_Null_TravelingTo_Should_Throw_ArgumentNullException()
    {
        // Arrange
        string departingFrom = "MAN";
        string travelingTo = null;
        DateTime departureDate = DateTime.Parse("2023/07/01");
        int duration = 7;

        // Act
        Action act = () => _holidaySearch = new HolidaySearch(
            departingFrom,
            travelingTo,
            departureDate,
            duration);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }
}
