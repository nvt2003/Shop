
using BusinessObjects.DTOs;

namespace Repositories.IRepository
{
    public interface IUserRepository
    {
        UserViewModel Login(LoginRequest loginRequest);
        bool Register(RegisterRequest registerRequest);
        List<UserViewModel> GetAllUsers();
    }
}
