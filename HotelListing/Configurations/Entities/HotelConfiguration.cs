using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Configurations.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
               new Hotel
               {
                   Id = 1,
                   Name = "Hotel 1",
                   Address = "Ha Noi",
                   CountryId = 1,
                   Rating = 4.7
               },
               new Hotel
               {
                   Id = 2,
                   Name = "Hotel 2",
                   Address = "Da Nang",
                   CountryId = 1,
                   Rating = 4.5
               },
               new Hotel
               {
                   Id = 3,
                   Name = "Hotel 3",
                   Address = "Tokyo",
                   CountryId = 2,
                   Rating = 4.3
               }
               , new Hotel
               {
                   Id = 4,
                   Name = "Hotel 4",
                   Address = "LonDon",
                   CountryId = 4,
                   Rating = 4.4
               }
               );
        }
    }
}
