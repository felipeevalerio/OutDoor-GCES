using Microsoft.EntityFrameworkCore;
using OutDoor_Models;
using OutDoor_Models.Models;
using OutDoor_Models.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public DbMainContext mainContext;
        public CategoryRepository( DbMainContext _mainContext)
        {
            mainContext = _mainContext;

        }
        public async Task<CategoryModel?> DeleteById(string id)
        {
            try
            {
                var category = await mainContext.Category.FirstOrDefaultAsync(c => c.Id == id);
                mainContext.Remove(category);
                await mainContext.SaveChangesAsync();
                return category;

            }
            catch (Exception ex)
            {
                throw new RepositoryException("A Unexpected Exception ocorrued while trying to delete a category") 
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Source = nameof(CategoryRepository)
                };

            }
        }

        public async Task<IEnumerable<CategoryModel>?> GetAll()
        {
            try
            {
                return await mainContext.Category.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new RepositoryException("A Unexpected Exception ocorrued while trying to get all categories")
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Source = nameof(CategoryRepository)
                };

            }
        }

        public async Task<CategoryModel?> GetById(string id)
        {
            try
            {
                return await mainContext.Category.FirstOrDefaultAsync(c => c.Id == id);

            }
            catch (Exception ex)
            {
                throw new RepositoryException("A Unexpected Exception ocorrued while trying to get a category by Id")
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Source = nameof(CategoryRepository)
                };

            }
        }
    }
}
