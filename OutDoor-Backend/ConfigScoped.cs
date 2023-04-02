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


            //Services
            builder.Services.AddScoped<IUserService, UserService>();

            return builder;
        }
    }
}
