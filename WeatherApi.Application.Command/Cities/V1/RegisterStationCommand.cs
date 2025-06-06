﻿

using MediatR;
using System.Text.Json.Serialization;

namespace WeatherApi.Application.Command.Cities.V1;

public record class RegisterStationCommand : IRequest<long>
{
    [JsonIgnore] public long Id { get; set; }
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    [JsonIgnore] public long CityId { get; set; }
}
