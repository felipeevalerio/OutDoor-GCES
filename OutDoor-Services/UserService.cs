using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OutDoor_Models.Models;
using OutDoor_Models.Repositorys;
using OutDoor_Models.Services;
using System.Net;
using System;
using System.Web.WebPages;
using OutDoor_Models.Requests.User;
using OutDoor_Services.UtilServices;

namespace OutDoor_Services
{
    public class UserService : IUserService
    {
        public IUserRepository UserRepository { get; set; }
        public ICryptographyService cryptographyService { get; set; }

        public UserService(IUserRepository userRepository,ICryptographyService cryptographyService)
        {
            this.UserRepository = userRepository;
            this.cryptographyService = cryptographyService;
        }

        public async Task<UserModel> CreateUser(CreateUserRequest user)
        {
            UserModel userToBeRegistred = new UserModel() {
                Id = Guid.NewGuid().ToString(),
                Name = user.Name,
                Email = user.Email,
                Password = cryptographyService.Encrypt(user.Password),
                UserType = user.UserType,
                CreatedAt = DateTime.Now
            };

            var useCreated = await UserRepository.CreateUser(userToBeRegistred);
            return useCreated;
        }

        public async Task<UserModel?> LoginUser(LoginRequest user)
        {
            var userFounded = await UserRepository.GetUserByEmail(user.Email);
            if (userFounded == null) throw new ServiceException("Usuário não pode ser encontrado")
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Source = nameof(UserRepository)
            };

            if (!user.Password.Equals(cryptographyService.Decrypt(userFounded.Password))) throw new ServiceException("Usuário e/ou senha incorretos") 
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Source = nameof(UserRepository)
            };

            return userFounded;

        }
    }
}
