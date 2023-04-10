using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OutDoor_Models.Models;
using OutDoor_Models.Services;

namespace OutDoor_Backend.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryService CategoryService { get; set; }

        public CategoryController(ICategoryService categoryService)
        {
            CategoryService = categoryService;
        }

        [HttpGet]
        [Route("/api/users/categories")]
        public async Task<IEnumerable<CategoryModel>?> getAllCategories()
        {
            return await CategoryService.getAllCategories();
        }
    }
}
