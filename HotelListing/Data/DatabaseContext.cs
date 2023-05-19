using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country() { Id = 1, Name = "VietNam", ShortName = "vn" },
                new Country() { Id = 2, Name = "Japan", ShortName = "jp" },
                new Country() { Id = 3, Name = "United State", ShortName = "us" },
                new Country() { Id = 4, Name = "United KingDom", ShortName = "uk" },
                new Country() { Id = 5, Name = "China", ShortName = "cn" }
                );
            builder.Entity<Hotel>().HasData(
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
