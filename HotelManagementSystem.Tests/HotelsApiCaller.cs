﻿using HotelManagementSystem.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;



namespace HotelManagementSystem.Tests
{
    public static class HotelsApiCaller
    {
        private static RestClient client = new RestClient("http://localhost:52475/api");
        public static List<Hotel> AddHotel(Hotel hotel)
        {
            var request = new RestRequest("Hotel", Method.POST);
            string json = JsonConvert.SerializeObject(hotel);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return JsonConvert.DeserializeObject<List<Hotel>>(content);
        }

        public static List<Hotel> GetAllHotels()
        {
            var request = new RestRequest("Hotel", Method.GET);
            //string json = JsonConvert.SerializeObject(hotel);
            //request.AddParameter("application/json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return JsonConvert.DeserializeObject<List<Hotel>>(content);
        }

        public static Hotel GetHotelById(int Id)
        {
            var request = new RestRequest(string.Format("Hotel/{0}",Id), Method.GET);
            string json = JsonConvert.SerializeObject(Id);
            request.AddParameter("application/json", json /*, ParameterType.UrlSegment*/);
            
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            //JObject jsonObj = JObject.Parse(json);
            return JsonConvert.DeserializeObject<Hotel>(content);
        }
    }
}
