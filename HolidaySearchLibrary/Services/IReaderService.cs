namespace HolidaySearchLibrary.Services;
public interface IReaderService<T>
{
    List<T> Read();
}