using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OutDoor_Models.Models;
using OutDoor_Models.Requests.Post;
using OutDoor_Models.Responses.Post;
using OutDoor_Models.Services;

namespace OutDoor_Backend.Controllers
{

    [ApiController]
    public class PostController : ControllerBase
    {

        public IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpPost]
        [Route("/api/post")]
        public async Task<string?> create([FromBody] CreatePostModelRequest request)
        {
            return await postService.createPost(request);

        }

        [HttpGet]
        [Route("/api/post")]
        public async Task<IEnumerable<InformationPostResponse>?> get([FromBody] CreatePostModelRequest request)
        {
            return await postService.getAllPosts();

        }

        [HttpDelete]
        [Route("/api/post")]
        public async Task<string> delete([FromQuery string postId)
        {
            return await postService.getAllPosts();

        }
    }
}
