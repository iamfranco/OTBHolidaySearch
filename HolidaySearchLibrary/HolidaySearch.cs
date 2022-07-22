﻿using HolidaySearchLibrary.Models;
using HolidaySearchLibrary.Services;

namespace HolidaySearchLibrary;
public class HolidaySearch
{
    public HolidaySearch(string departingFrom, string travelingTo, DateTime departureDate, int duration)
    {
        if (departingFrom is null)
            throw new ArgumentNullException(nameof(departingFrom));

        if (travelingTo is null)
            throw new ArgumentNullException(nameof(travelingTo));

        string currentDirectory = Directory.GetCurrentDirectory();
        string flightFilePath = currentDirectory + @"\dataFiles\flightData.json";
        string hotelFilePath = currentDirectory + @"\dataFiles\hotelData.json";

        IReaderService<Flight> flightReaderService = new ReaderService<Flight>(flightFilePath);
        IReaderService<Hotel> hotelReaderService = new ReaderService<Hotel>(hotelFilePath);

        IFlightSearchService flightSearchService = new FlightSearchService(flightReaderService);
        IHotelSearchService hotelSearchService = new HotelSearchService(hotelReaderService);

        HolidaySearchService holidaySearchService = new HolidaySearchService(flightSearchService, hotelSearchService);

        Results = holidaySearchService.Search(departingFrom, travelingTo, departureDate, duration);
    }

    public List<Holiday> Results { get; }
}