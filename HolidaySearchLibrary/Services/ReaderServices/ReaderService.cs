using System.Text.Json;

namespace HolidaySearchLibrary.Services.ReaderServices;
public class ReaderService<T> : IReaderService<T>
{
    private string _filePath;

    public ReaderService(string filePath)
    {
        if (filePath is null)
            throw new ArgumentNullException(nameof(filePath));

        _filePath = filePath;
    }

    public List<T> Read()
    {
        string jsonString = File.ReadAllText(_filePath);

        return JsonSerializer.Deserialize<List<T>>(jsonString);
    }
}
