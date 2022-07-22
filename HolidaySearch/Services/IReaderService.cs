namespace HolidaySearch.Services;
public interface IReaderService<T>
{
    List<T> Read();
}