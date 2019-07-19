﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models.DataModels;

namespace WeatherApp.Api
{
    public class OpenWeatherApi
    {
        private string _apiHost = "http://api.openweathermap.org/data/2.5/";
        private string _apiKey = "3f6a689c2ab05208a789a8858d595c07";
        private string _units = "metric";
        private string _city;

        public OpenWeatherApi(string city)
        {
            _city = city;
        }

        HttpClient _httpClient = new HttpClient();
        
        public async Task<CurrentWeatherDataModel.RootObject> GetCurrentWeather()
        {
            var response = await _httpClient.GetAsync($"{_apiHost}weather?q={_city}&appid={_apiKey}&units={_units}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CurrentWeatherDataModel.RootObject>(content);
        }

        public async Task<DailyWeatherDataModel.RootObject> GetDailyWeather()
        {
            var response = await _httpClient.GetAsync($"{_apiHost}forecast?q={_city}&appid={_apiKey}&units={_units}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DailyWeatherDataModel.RootObject>(content);
        }
    }
}