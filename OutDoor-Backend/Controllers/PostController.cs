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
        public async Task<InformationPostResponse?> Create([FromBody] CreatePostModelRequest request)
        {
            return await postService.createPost(request);

        }

        [HttpGet]
        [Route("/api/post")]
        public async Task<IEnumerable<InformationPostResponse>?> Get()
        {
            return await postService.getAllPosts();

        }

        [HttpGet]
        [Route("/api/post/{postId}")]
        public async Task<InformationPostResponse?> GetPostById([FromRoute(Name = "postId")] string postId)
        {
            return await postService.getPostInfoById(postId);
        }


        [HttpDelete]
        [Route("/api/post")]
        public async Task<ActionResult> Delete([FromQuery] string postId)
        {

            var result =  await postService.removePostById(postId);

            return result == null ? NotFound() : Ok(result);

        }

        [HttpPut]
        [Route("/api/post")]
        public async Task<ActionResult> Edit([FromBody] EditPostModelRequestModel post)
        {
            var result = await postService.EditPost(post);

            return result == null ? NotFound() : Ok(result);

        }
    }
}
