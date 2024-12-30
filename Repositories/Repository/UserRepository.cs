
using BusinessObjects.DTOs;
using DataAccess.DAO;
using Repositories.IRepository;

namespace Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        private UserDAO _userDAO;
        public UserRepository(UserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public List<UserViewModel> GetAllUsers()
        {
            return _userDAO.GetAllUsers();
        }

        public UserViewModel Login(LoginRequest loginRequest)
        {
            return _userDAO.Login(loginRequest);
        }

        public bool Register(RegisterRequest registerRequest)
        {
            return _userDAO.Resgister(registerRequest);
        }
    }
}
