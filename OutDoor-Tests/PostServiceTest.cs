using OutDoor_Models.Models;
using OutDoor_Models.Repository;
using OutDoor_Models.Repositorys;
using OutDoor_Models.Requests.Post;
using OutDoor_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Tests
{
    public class PostServiceTest
    {
        [Fact]
        public async void CreatePostTest() { 
            
            //Arrange
            Moq.Mock<IPostRepository> postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(x => x.createNewPost(It.IsAny<PostModel>()).Result).Returns(new PostModel());
            Moq.Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetById(It.Is<string>(x => x == "1")).Result).Returns(new UserModel() { UserType = "provider"});
            Moq.Mock<ICommentRepository> commentRepositoryMock = new Mock<ICommentRepository>();
            var postService = new PostService(postRepositoryMock.Object, userRepositoryMock.Object, commentRepositoryMock.Object);

            //Act
            var creatPostResponse = await postService.createPost(new CreatePostModelRequest()
            {
                UserId = "1"
            });

            //Assert
            Assert.NotNull(creatPostResponse);

        }

        [Fact]
        public async void CreatePostFailedIsNotProviderTest()
        {

            //Arrange
            Moq.Mock<IPostRepository> postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(x => x.createNewPost(It.IsAny<PostModel>()).Result).Returns(new PostModel());
            Moq.Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetById(It.Is<string>(x => x == "1")).Result).Returns(new UserModel() { UserType = "client" });
            Moq.Mock<ICommentRepository> commentRepositoryMock = new Mock<ICommentRepository>();
            var postService = new PostService(postRepositoryMock.Object, userRepositoryMock.Object, commentRepositoryMock.Object);

            //Act then Assert
            await Assert.ThrowsAsync<ServiceException>(async () =>
            {
                await postService.createPost(new CreatePostModelRequest()
                {
                    UserId = "1"
                });
            });

        }

        [Fact]
        public async void GetAllPostsTest()
        {

            //Arrange
            Moq.Mock<IPostRepository> postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(x => x.getAllPosts().Result).Returns(new List<PostModel>() { new PostModel(){
                Id = "123",
                UserId = "1",
            }});
            Moq.Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetById(It.Is<string>(x => x == "1")).Result).Returns(new UserModel() { 
                Id = "1"
            });
            Moq.Mock<ICommentRepository> commentRepositoryMock = new Mock<ICommentRepository>();
            commentRepositoryMock.Setup(x => x.getCommentsByPostId(It.Is<string>(x => x == "123"))).Returns(new List<CommentModel>() {
                new CommentModel()
            }) ;

            var postService = new PostService(postRepositoryMock.Object, userRepositoryMock.Object, commentRepositoryMock.Object);

            //Act
            var posts = await postService.getAllPosts();

            //Assert
            Assert.NotNull(posts);
            Assert.Equal<int>(1, posts == null ? 0 : posts.Count());

        }


        [Fact]
        public async void GetAllPostsReturnsNothingTest()
        {

            //Arrange
            Moq.Mock<IPostRepository> postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(x => x.getAllPosts().Result).Returns((List<PostModel>?) null);
            Moq.Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Moq.Mock<ICommentRepository> commentRepositoryMock = new Mock<ICommentRepository>();


            var postService = new PostService(postRepositoryMock.Object, userRepositoryMock.Object, commentRepositoryMock.Object);

            //Act
            var posts = await postService.getAllPosts();

            //Assert
            Assert.Null(posts);

        }


        [Fact]
        public async void GetPostInfoTest()
        {

            //Arrange
            Moq.Mock<IPostRepository> postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(x => x.getPostById(It.Is<string>(x => x == "123")).Result).Returns( new PostModel(){
                Id = "123",
                UserId = "1",
            });
            Moq.Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetById(It.Is<string>(x => x == "1")).Result).Returns(new UserModel()
            {
                Id = "1"
            });
            Moq.Mock<ICommentRepository> commentRepositoryMock = new Mock<ICommentRepository>();
            commentRepositoryMock.Setup(x => x.getCommentsByPostId(It.Is<string>(x => x == "123"))).Returns(new List<CommentModel>() {
                new CommentModel()
            });


            var postService = new PostService(postRepositoryMock.Object, userRepositoryMock.Object, commentRepositoryMock.Object);

            //Act
            var post = await postService.getPostInfoById("123");

            //Assert
            Assert.NotNull(post);

        }
    }
}
