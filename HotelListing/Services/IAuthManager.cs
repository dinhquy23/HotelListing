using HotelListing.Models;
using System.Threading.Tasks;

namespace HotelListing.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDTO loginDTO);
        Task<string> CreateToken();
    }
}
