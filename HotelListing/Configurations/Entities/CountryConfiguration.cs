using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Configurations.Entities
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country() { Id = 1, Name = "VietNam", ShortName = "vn" },
                new Country() { Id = 2, Name = "Japan", ShortName = "jp" },
                new Country() { Id = 3, Name = "United State", ShortName = "us" },
                new Country() { Id = 4, Name = "United KingDom", ShortName = "uk" },
                new Country() { Id = 5, Name = "China", ShortName = "cn" }
                );
        }
    }
}
