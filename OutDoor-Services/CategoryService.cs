using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OutDoor_Models.Models;
using OutDoor_Models.Repositorys;
using OutDoor_Models.Services;
using System.Net;
using System;
using OutDoor_Models.Requests.User;
using OutDoor_Services.UtilServices;

namespace OutDoor_Services
{
    public class CategoryService : ICategoryService
    {
        public ICategoryRepository GategoryRepository { get; set; }

        public CategoryService(ICategoryRepository _GategoryRepository)
        {
            GategoryRepository = _GategoryRepository;
        }

        public async Task<CategoryModel?> getCategoryById(string Id)
        {
            return await GategoryRepository.GetById(Id);
        }

        public async Task<IEnumerable<CategoryModel>?> getAllCategories()
        {
            return await GategoryRepository.GetAll();

        }

        public async Task<CategoryModel?> deleteGategoryById(string id)
        {
            return await GategoryRepository.DeleteById(id);

        }
    }
}
