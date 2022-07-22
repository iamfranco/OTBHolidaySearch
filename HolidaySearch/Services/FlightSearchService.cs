using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Services;
public class FlightSearchService
{
    private IFlightReaderService _flightReaderService;

    public FlightSearchService(IFlightReaderService flightReaderService)
    {
        if (flightReaderService is null)
            throw new ArgumentNullException(nameof(flightReaderService));

        _flightReaderService = flightReaderService;
    }
}
