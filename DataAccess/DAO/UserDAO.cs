

using AutoMapper;
using BusinessObjects;
using BusinessObjects.DTOs;
using BusinessObjects.Models;

namespace DataAccess.DAO
{
    public class UserDAO
    {
        private readonly ShopDBContext _context;
        private readonly IMapper _mapper;
        public UserDAO(ShopDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public UserViewModel Login(LoginRequest loginRequest)
        {
            var user = _context.Users.FirstOrDefault(u=>u.Username==loginRequest.Username&&u.Password==loginRequest.Password);
            var userVM = _mapper.Map<UserViewModel>(user);
            return userVM;
        }
        public bool Resgister(RegisterRequest registerRequest)
        {
            try
            {
                var user = _mapper.Map<User>(registerRequest);
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<UserViewModel> GetAllUsers()
        {
            var users = _context.Users.ToList();
            var userVMs = _mapper.Map<List<UserViewModel>>(users);
            return userVMs;
        }
    }
}
