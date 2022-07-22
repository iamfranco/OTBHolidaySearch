namespace HolidaySearchLibrary.Services.ReaderServices;
public interface IReaderService<T>
{
    List<T> Read();
}