﻿using HolidaySearchLibrary.Models;
using HolidaySearchLibrary.Services.ReaderServices;

namespace HolidaySearchLibrary.Services.HotelServices;
public class HotelSearchService : IHotelSearchService
{
    private readonly IReaderService<Hotel> _hotelReaderService;

    public HotelSearchService(IReaderService<Hotel> hotelReaderService)
    {
        if (hotelReaderService is null)
            throw new ArgumentNullException(nameof(hotelReaderService));

        _hotelReaderService = hotelReaderService;
    }

    public List<Hotel> Search(string localAirport, DateTime arrivalDate, int duration)
    {
        if (localAirport is null)
            throw new ArgumentNullException(nameof(localAirport));

        List<Hotel> hotels = _hotelReaderService.Read();

        return hotels.Where(hotel =>
            IsLocalAirportMatching(hotel, localAirport) &&
            IsArrivalDateMatching(hotel, arrivalDate) &&
            IsDurationMatching(hotel, duration)
            ).ToList();
    }

    private static bool IsLocalAirportMatching(Hotel hotel, string localAirport) => 
        hotel.LocalAirports.Contains(localAirport);

    private static bool IsArrivalDateMatching(Hotel hotel, DateTime arrivalDate) =>
        hotel.ArrivalDate == arrivalDate;

    private static bool IsDurationMatching(Hotel hotel, int duration) =>
        hotel.Nights == duration;
}
