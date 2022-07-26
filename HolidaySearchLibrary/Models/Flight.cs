﻿using System.Text.Json.Serialization;

namespace HolidaySearchLibrary.Models;
public class Flight
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("airline")]
    public string Airline { get; set; }

    [JsonPropertyName("from")]
    public string DepartingFrom { get; set; }

    [JsonPropertyName("to")]
    public string TravelingTo { get; set; }

    [JsonPropertyName("price")]
    public int Price { get; set; }

    [JsonPropertyName("departure_date")]
    public DateTime DepartureDate { get; set; }
}