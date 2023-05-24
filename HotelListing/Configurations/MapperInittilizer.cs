using AutoMapper;
using HotelListing.Data;
using HotelListing.Models;
using System.Runtime;

namespace HotelListing.Configurations
{
    public class MapperInittilizer:Profile
    {
        public MapperInittilizer()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();    
            CreateMap<Country, CreateCountryDTO>().ReverseMap();    
            CreateMap<Hotel, HotelDTO>().ReverseMap();    
            CreateMap<Hotel, CreateHotelDTO>().ReverseMap(); 
            CreateMap<ApiUser,UserDTO>().ReverseMap();
        }
    }
}
 