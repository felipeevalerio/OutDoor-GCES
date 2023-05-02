using OutDoor_Models;
using OutDoor_Models.Models;
using OutDoor_Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Repository
{
    public class CommentRepository : ICommentRepository
    {
        public DbMainContext mainContext;

        public CommentRepository(DbMainContext mainContext)
        {
            this.mainContext = mainContext;
        }

        public async Task<CommentModel> createNewComent(CreateCommentRequestModel comment)
        {

            try
            {
                var result = (await mainContext.Comment.AddAsync(new CommentModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    Image = comment.Image,
                    Review = comment.Review,
                    CreatedAt = DateTime.Now,
                    UserId = comment.UserId,
                    PostId = comment.PostId

                })).Entity;

                await mainContext.SaveChangesAsync();
                return result;

            }
            catch (Exception ex)
            {
                throw new RepositoryException("Um erro inesperado ocorreu ao publicar o comentario")
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Source = nameof(CommentRepository)
                };
            }
        }

        public IEnumerable<CommentModel> getCommentsByPostId(string postId)
        {
            try
            {
                return mainContext.Comment.Where(c => c.PostId == postId);

            }
            catch (Exception ex)
            {
                throw new RepositoryException("Um erro inesperado ocorreu ao buscar os comentarios de um post")
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Source = nameof(CommentRepository)
                };
            }
            
        }
    }
}
