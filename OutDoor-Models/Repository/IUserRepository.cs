using OutDoor_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Models.Repositorys
{
    public interface IUserRepository
    {
        public  Task<UserModel> GetById(string id);
        public  Task<IEnumerable<UserModel>> GetAll();
        public Task<UserModel> DeleteById(string id );
        public Task<UserModel> CreateUser(UserModel user);
        public Task<UserModel> UpdateUser(UserModel user);
        public Task<UserModel?> GetUserByEmail(string email);
     
    }
}
