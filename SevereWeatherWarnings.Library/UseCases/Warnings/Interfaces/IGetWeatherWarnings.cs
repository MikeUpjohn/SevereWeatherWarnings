﻿using SevereWeatherWarnings.Models;
using SevereWeatherWarnings.Models.API;

namespace SevereWeatherWarnings.Library.UseCases.Warnings.Interfaces
{
    public interface IGetWeatherWarnings
    {
        Task<WeatherWarningsResponse> GetActiveWeatherWarnings(RetrieveDataRequest request);
    }
}