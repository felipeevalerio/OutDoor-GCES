using OutDoor_Models;
using OutDoor_Models.Models;
using OutDoor_Models.Services;
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
