using OutDoor_Models.Repository;
using OutDoor_Models.Repositorys;
using OutDoor_Models.Services;
using OutDoor_Repository;
using OutDoor_Services;
using OutDoor_Services.UtilServices;
using System.Security.Cryptography;

namespace OutDoor_Backend
{
    public class ConfigScoped
    {
        public WebApplicationBuilder ConfigureServiceScopes(WebApplicationBuilder builder)
        {

            //Repositories
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();


            //Services
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddScoped<ICryptographyService, CryptographyService>();
            builder.Services.AddScoped<IRabbitMQService, RabbitMQService>();
            builder.Services.AddScoped<ICommentService, CommentService>();

            return builder;
        }
    }
}
