using OutDoor_Models.Models;
using OutDoor_Models.Repositorys;
using OutDoor_Models.Requests.Post;
using OutDoor_Models.Responses.Post;
using OutDoor_Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Services
{
    public class PostService : IPostService
    {   
        public IPostRepository PostRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public ICommentRepository CommentRepository { get; set; }
        public PostService(IPostRepository postRepository, IUserRepository userRepository, ICommentRepository commentRepository)
        {
            PostRepository = postRepository;
            UserRepository = userRepository;
            CommentRepository = commentRepository;
        }

        public async Task<string> createPost(CreatePostModelRequest request)
        {
            var post = new PostModel()
            {

                Id = Guid.NewGuid().ToString(),
                UserId = request.UserId,
                CategoryId = request.CategoryId,
                Title = request.Title,
                City = request.City,
                MobileNumber = request.ContactNumber,
                District = request.District,
                State = request.State,
                Description = request.Description,
                Image = request.Image,
                Rating = 0,
                CreatedAt = DateTime.Now
            };

            var createdPost = await PostRepository.createNewPost(post);

            return createdPost.Id;
        }

        public async Task<IEnumerable<InformationPostResponse>?> getAllPosts()
        {
            var posts = await PostRepository.getAllPosts();

            if (posts == null) return null;

            var reponsePosts = new List<InformationPostResponse>();

            foreach (var post in posts)
            {
                reponsePosts.Add(new InformationPostResponse() { 
                    Id = post.Id,
                    //Get User by Id
                    User = await UserRepository.GetById(post.Id),
                    CategoryId = post.CategoryId,
                    Title= post.Title,
                    City= post.City,
                    MobileNumber = post.MobileNumber,
                    District = post.District,
                    State = post.State,
                    Description = post.Description,
                    Image = post.Image,
                    Rating = post.Rating,
                    CreatedAt = post.CreatedAt,
                    Comments = CommentRepository.getCommentsByPostId(post.Id),

                });
            }

            return reponsePosts;
        }

        public async Task<string?> removePostById(string postId)
        {
            return await PostRepository.deletePost(postId);
        }
    }
}
