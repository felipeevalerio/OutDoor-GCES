using OutDoor_Models.Models;
using OutDoor_Models.Requests.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Models.Repositorys
{
    public interface IPostRepository
    {
        public Task<IEnumerable<PostModel>?> getAllPosts();
        public Task<PostModel> createNewPost(PostModel post);
        public  Task<string?> deletePost(string postId);
        public  Task<PostModel?> getPostById(string postId);
        public Task<PostModel?> UpdatePost(EditPostModelRequestModel post);


    }
}
