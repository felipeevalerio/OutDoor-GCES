using OutDoor_Models.Repositorys;
using OutDoor_Models.Services;
using OutDoor_Repository;
using OutDoor_Services;

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


            return builder;
        }
    }
}
