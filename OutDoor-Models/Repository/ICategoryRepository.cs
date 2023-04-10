using OutDoor_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Models.Repositorys
{
    public interface ICategoryRepository
    {
        public  Task<CategoryModel?> GetById(string id);
        public  Task<IEnumerable<CategoryModel>?> GetAll();
        public Task<CategoryModel?> DeleteById(string id );
     
    }
}
