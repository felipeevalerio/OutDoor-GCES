using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OutDoor_Models.Models;
using OutDoor_Models.Repositorys;
using OutDoor_Models.Services;
using System.Net;
using System;
using System.Web.WebPages;
using OutDoor_Models.Requests.User;
using OutDoor_Services.UtilServices;
using System.Reflection.Metadata.Ecma335;

namespace OutDoor_Services
{
    public class UserService : IUserService
    {
        public IUserRepository UserRepository { get; set; }
        public IPostRepository PostRepository { get; set; }
        public ICryptographyService cryptographyService { get; set; }

        public UserService(IUserRepository userRepository,ICryptographyService cryptographyService, IPostRepository postRepository)
        {
            this.UserRepository = userRepository;
            this.cryptographyService = cryptographyService;
            this.PostRepository = postRepository;
        }

        public async Task<UserModel> CreateUser(CreateUserRequest user)
        {
            UserModel userToBeRegistred = new UserModel() {
                Id = Guid.NewGuid().ToString(),
                Name = user.Name,
                Email = user.Email,
                //Password = cryptographyService.Encrypt(user.Password),
                Password = user.Password,
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

            //if (!user.Password.Equals(cryptographyService.Decrypt(userFounded.Password))) throw new ServiceException("Usuário e/ou senha incorretos") 
            if (!user.Password.Equals(userFounded.Password)) throw new ServiceException("Usuário e/ou senha incorretos") 
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Source = nameof(UserRepository)
            };

            return userFounded;

        }

        public async Task<UserModel?> EditUserData(EditUserRequest user)
        {
            var userFounded = await UserRepository.GetById(user.ID);
            if (userFounded == null) throw new ServiceException("Usuário não pode ser encontrado")
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Source = nameof(UserRepository)
            };
            userFounded.Name = user.Name;
            userFounded.Email = user.Email;
            userFounded.Avatar = user.Avatar;
            await UserRepository.UpdateUser(userFounded);

            return userFounded;

        }

        public async Task<List<PostModel>> GetPosts(string ID)
        {

            var posts = await PostRepository.getAllPosts();

            return posts == null ? new List<PostModel>() : posts.Where(p => p.UserId == ID).ToList();
        }

        public async Task<string?> DeleteUserPost(string ID)
        {
            return await PostRepository.deletePost(ID);
        }
    }
}
