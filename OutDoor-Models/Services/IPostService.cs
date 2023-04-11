using OutDoor_Models.Models;
using OutDoor_Models.Requests.Post;
using OutDoor_Models.Responses.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Models.Services
{
    public interface IPostService
    {

        public Task<string> createPost(CreatePostModelRequest request);

        public Task<IEnumerable<InformationPostResponse>?> getAllPosts();
    }
}
