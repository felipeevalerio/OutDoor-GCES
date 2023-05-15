using OutDoor_Models.Models;
using OutDoor_Models.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Models.Services
{
    public interface IUserService
    {
        public Task<UserModel> CreateUser(CreateUserRequest user);
        public Task<UserModel?> LoginUser(LoginRequest user);
        public Task<List<PostModel>> GetPosts(string ID);

    }
}
