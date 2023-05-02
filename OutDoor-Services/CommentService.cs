using OutDoor_Models.Models;
using OutDoor_Models.Repository;
using OutDoor_Models.Repositorys;
using OutDoor_Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Services
{
    public class CommentService : ICommentService
    {
        public ICommentRepository commentRepository { get; set; }
        public IUserRepository userRepository { get; set; }
        public CommentService(ICommentRepository commentRepository, IUserRepository userRepository)
        {
            this.commentRepository = commentRepository;
            this.userRepository = userRepository;
        }

        public async Task<CommentModel> postNewComment(CreateCommentRequestModel request)
        {
            if ((await userRepository.GetById(request.UserId)).UserType != "client") throw new ServiceException("Apenas clientes podem criar comentários")
            {
                StatusCode = HttpStatusCode.Forbidden,
                Source = nameof(CommentService)
            };

            return await commentRepository.createNewComent(request);

        }
    }
}
