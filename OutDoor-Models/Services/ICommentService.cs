using OutDoor_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Models.Services
{
    public interface ICommentService
    {
        public Task<CommentModel> postNewComment(CreateCommentRequestModel request);
    }
}
