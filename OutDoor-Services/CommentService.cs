using OutDoor_Models.Models;
using OutDoor_Models.Repository;
using OutDoor_Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Services
{
    public class CommentService : ICommentService
    {
        public ICommentRepository commentRepository { get; set; }
        public CommentService(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public async Task<CommentModel> postNewComment(CreateCommentRequestModel request)
        {
            return await commentRepository.createNewComent(request);

        }
    }
}
