using OutDoor_Models.Models;
using OutDoor_Models.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Models.Services
{
    public interface ICategoryService
    {
        public Task<CategoryModel?> getCategoryById(string Id);

        public Task<IEnumerable<CategoryModel>?> getAllCategories();
    }
}
