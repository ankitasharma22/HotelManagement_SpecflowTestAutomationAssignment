using FluentAssertions;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class AddHotelSteps
    {
        private Hotel hotel = new Hotel();
        private Hotel addHotelResponse;
        private List<Hotel> hotels = new List<Hotel>();
        private List<int> hotelIds = new List<int>();

        [Given(@"User provided valid Id '(.*)' and '(.*)' for hotel")]
        [Given(@"User provided valid Id '(.*)'  and '(.*)'for hotel")]
        public void GivenUserProvidedValidIdAndForHotel(int id, string name)
        {
            hotel.Id = id;
            hotel.Name = name;
        }

        [Given(@"Use has added required details for hotel")]
        public void GivenUseHasAddedRequiredDetailsForHotel()
        {
            SetHotelBasicDetails();
        }

        [When(@"User calls AddHotel api")]
        [Given(@"User calls AddHotel api")]
        public void WhenUserCallsAddHotelApi()
        {
            hotelIds.Add(hotel.Id);
            hotels = HotelsApiCaller.AddHotel(hotel);
        }

        [Then(@"Hotel with name '(.*)' should be present in the response")]
        public void ThenHotelWithNameShouldBePresentInTheResponse(string name)
        {
            hotel = hotels.Find(htl => htl.Name.ToLower().Equals(name.ToLower()));
            hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response", name));
        }


        private void SetHotelBasicDetails()
        {
            hotel.ImageURLs = new List<string>() { "image1", "image2" };
            hotel.LocationCode = "Location";
            hotel.Rooms = new List<Room>() { new Room() { NoOfRoomsAvailable = 10, RoomType = "delux" } };
            hotel.Address = "Address1";
            hotel.Amenities = new List<string>() { "swimming pool", "gymnasium" };
        }

        [When(@"User calls GetHotels api")]
        public void WhenUserCallsGetHotelsApi()
        {
            hotels = HotelsApiCaller.GetAllHotels();
        }


        [When(@"User calls GetHotelById api")]
        public void WhenUserCallsGetHotelByIdApi()
        {
            //   hotel = HotelsApiCaller.GetHotelById(Id);
        }


        [Then(@"Hotels in the database should be displayed")]
        public void ThenAllHotelsShouldBeDisplayed()
        {
            for (int i = 0; i <hotelIds.Count; i++)
            {
                hotel = hotels.Find(h1 => h1.Id == hotels[i].Id);
                hotel.Should().NotBeNull(string.Format("Hotel {0} not found", hotels[i].Id)); //check if id exsists
            }
        }

        [Then(@"Hotels matching the id '(.*)' should be displayed")]
        public void ThenHotelWithMatchingIdShouldBeDisplayed(int Id)
        {
            hotel = HotelsApiCaller.GetHotelById(Id);
            hotel.Should().NotBeNull(string.Format("Hotel with id {0} not found in response", Id));
        }
    }
}
