using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
}
