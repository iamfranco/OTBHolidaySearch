﻿using HolidaySearchLibrary.Models;
using HolidaySearchLibrary.Services;
using HolidaySearchLibrary.Services.FlightServices;
using HolidaySearchLibrary.Services.HotelServices;
using HolidaySearchLibrary.Services.ReaderServices;

namespace HolidaySearchLibrary;
public class HolidaySearch
{
    public List<Holiday> Results { get; }

    public HolidaySearch(List<string> departingFrom, string travelingTo, DateTime departureDate, int duration)
    {
        if (departingFrom is null)
            throw new ArgumentNullException(nameof(departingFrom));

        if (travelingTo is null)
            throw new ArgumentNullException(nameof(travelingTo));

        HolidaySearchService holidaySearchService = RegisterServices();

        Results = holidaySearchService.Search(departingFrom, travelingTo, departureDate, duration);
    }

    private static HolidaySearchService RegisterServices()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string flightFilePath = currentDirectory + @"\JsonFiles\FlightData.json";
        string hotelFilePath = currentDirectory + @"\JsonFiles\HotelData.json";

        IReaderService<Flight> flightReaderService = new ReaderService<Flight>(flightFilePath);
        IReaderService<Hotel> hotelReaderService = new ReaderService<Hotel>(hotelFilePath);

        IFlightSearchService flightSearchService = new FlightSearchService(flightReaderService);
        IHotelSearchService hotelSearchService = new HotelSearchService(hotelReaderService);

        HolidaySearchService holidaySearchService = new HolidaySearchService(flightSearchService, hotelSearchService);
        return holidaySearchService;
    }
}
