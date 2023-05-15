using Microsoft.EntityFrameworkCore;
using OutDoor_Models;
using OutDoor_Models.Models;
using OutDoor_Models.Repositorys;
using OutDoor_Models.Requests.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Repository
{
    public class PostRepository : IPostRepository
    {
        public DbMainContext MainContext { get; set; }

        public PostRepository(DbMainContext _mainContext)
        {
            MainContext = _mainContext;
        }

        public async Task<IEnumerable<PostModel>?> getAllPosts()
        {
            try
            {
                return await MainContext.Post.ToListAsync();

            }catch(Exception ex)
            {
                throw new RepositoryException("Um erro inesperado ocorreu ao listar todos os posts")
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Source = nameof(PostRepository)
                };
            }
        }

        public async Task<PostModel?> getPostById(string postId)
        {
            try
            {
                return await MainContext.Post.FirstOrDefaultAsync(p => p.Id == postId);

            }
            catch (Exception ex)
            {
                throw new RepositoryException("Um erro inesperado ocorreu ao listar todos os posts")
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Source = nameof(PostRepository)
                };
            }
        }

        public async Task<PostModel> createNewPost(PostModel post)
        {
            try
            {
                var result = await MainContext.Post.AddAsync(post);
                await MainContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Um erro inesperado ocorreu ao criar um post")
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Source = nameof(PostRepository)
                };
            }

        }

        public async Task<string?> deletePost(string postId)
        {
            try
            {
                var post = await MainContext.Post.FirstOrDefaultAsync(p => p.Id == postId);
                if (post == null) return null;
                var result = MainContext.Post.Remove(post).Entity.Id;
                await MainContext.SaveChangesAsync();
                return result;
            }   
            catch (Exception ex)
            {
                throw new RepositoryException("Um erro inesperado ocorreu ao deletar um post")
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Source = nameof(PostRepository)
                };
            }

        }

        public async Task<PostModel?> UpdatePost(EditPostModelRequestModel Post)
        {
            try
            {
                var post = await MainContext.Post.FirstOrDefaultAsync(p => p.Id == Post.Id);
                if (post == null) return null;
                var result = MainContext.Post.Update(post).Entity;
                await MainContext.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Um erro inesperado ocorreu ao editar um post")
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Source = nameof(PostRepository)
                };
            }
        }
    }
}
