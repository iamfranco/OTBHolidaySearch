using HolidaySearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HolidaySearch.Services;
public class FlightReaderService
{
    private string _filePath;

    public FlightReaderService(string filePath)
    {
        if (filePath is null)
            throw new ArgumentNullException(nameof(filePath));

        _filePath = filePath;
    }

    public List<Flight> Read()
    {
        string jsonString = File.ReadAllText(_filePath);

        List<Flight> flights = JsonSerializer.Deserialize<List<Flight>>(jsonString);

        return flights;
    }
}
