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
                CategoryId = "456",
                Title = "TestTitle",
                City = "Cidade",
                MobileNumber = "34",
                District = "MG",
                State = "MG2",
                Description = "desc",
                Image = "img",
                Rating = 5.0,
                CreatedAt = DateTime.Today
                
            });
            Moq.Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetById(It.Is<string>(x => x == "1")).Result).Returns(new UserModel()
            {
                Id = "1",
                
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
            Assert.Equal("123", post.Id);
            Assert.Equal("1",post.User.Id);
            Assert.Equal("456", post.CategoryId);
            Assert.Equal("TestTitle", post.Title);
            Assert.Equal("Cidade", post.City);
            Assert.Equal("34", post.ContactNumber);
            Assert.Equal("MG", post.District);
            Assert.Equal("MG2", post.State);
            Assert.Equal("desc", post.Description);
            Assert.Equal("img", post.Image);
            Assert.Equal(5.0,  post.Rating);
            Assert.Equal(5.0, post.Rating);
            Assert.Equal(DateTime.Today, post.CreatedAt);
            Assert.NotNull(post.Comments);
            Assert.Equal(1, post.Comments == null ? 0 : post.Comments.Count());

    }


        [Fact]
        public async void GetPostInfoPostNotFoundTest()
        {

            //Arrange
            Moq.Mock<IPostRepository> postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(x => x.getPostById(It.Is<string>(x => x == "123")).Result).Returns((PostModel?) null);
            Moq.Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Moq.Mock<ICommentRepository> commentRepositoryMock = new Mock<ICommentRepository>();


            var postService = new PostService(postRepositoryMock.Object, userRepositoryMock.Object, commentRepositoryMock.Object);

            //Act
            var post = await postService.getPostInfoById("123");

            //Assert
            Assert.Null(post);

        }


        [Fact]
        public async void RemovePostTest()
        {

            //Arrange
            Moq.Mock<IPostRepository> postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(x => x.deletePost(It.Is<string>(x => x == "1")).Result).Returns("1");
            Moq.Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Moq.Mock<ICommentRepository> commentRepositoryMock = new Mock<ICommentRepository>();


            var postService = new PostService(postRepositoryMock.Object, userRepositoryMock.Object, commentRepositoryMock.Object);

            //Act
            var postDeletedId = await postService.removePostById("1");

            //Assert
            Assert.Equal("1", postDeletedId);

        }

        [Fact]
        public async void EditPostTest()
        {

            //Arrange
            Moq.Mock<IPostRepository> postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(x => x.UpdatePost(It.IsAny<PostModel>()).Result).Returns(new PostModel());
            Moq.Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Moq.Mock<ICommentRepository> commentRepositoryMock = new Mock<ICommentRepository>();


            var postService = new PostService(postRepositoryMock.Object, userRepositoryMock.Object, commentRepositoryMock.Object);

            //Act
            var postEdited = await postService.EditPost(new EditPostModelRequestModel()
            {
                Id = "123",
                Title = "teste"
            });

            //Assert
            Assert.NotNull(postEdited);

        }

        [Fact]
        public async void AddNewRatingTest()
        {

            //Arrange
            Moq.Mock<IPostRepository> postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(x => x.getPostById(It.Is<string>(x => x == "123")).Result).Returns(new PostModel()
            {
                NumberOfRatings = 1,
                Rating = 4.0
            });
            postRepositoryMock.Setup(x => x.UpdatePost(It.IsAny<PostModel>()).Result).Returns((PostModel x) => x); 

            Moq.Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Moq.Mock<ICommentRepository> commentRepositoryMock = new Mock<ICommentRepository>();

            var postService = new PostService(postRepositoryMock.Object, userRepositoryMock.Object, commentRepositoryMock.Object);

            //Act
            var postRated = await postService.AddNewRating("123", 5);

            //Assert
            Assert.Equal(4.5, postRated.Rating == null ? 0.0 : postRated.Rating);
            Assert.Equal(2, postRated.NumberOfRatings == null ? 0 : postRated.NumberOfRatings);
        }


        [Fact]
        public async void AddNewRatingToNotFoundPostTest()
        {

            //Arrange
            Moq.Mock<IPostRepository> postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(x => x.getPostById(It.Is<string>(x => x == "123")).Result).Returns((PostModel?) null);
            Moq.Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Moq.Mock<ICommentRepository> commentRepositoryMock = new Mock<ICommentRepository>();

            var postService = new PostService(postRepositoryMock.Object, userRepositoryMock.Object, commentRepositoryMock.Object);

            //Act
            var postRated = await postService.AddNewRating("123", 5);

            //Assert
            Assert.Null(postRated);
        }

        [Fact]
        public async void AddNewRatingToNullRatingPost()
        {

            //Arrange
            Moq.Mock<IPostRepository> postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(x => x.getPostById(It.Is<string>(x => x == "123")).Result).Returns(new PostModel() {
                Rating = null,
                NumberOfRatings = null
            });

            Moq.Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Moq.Mock<ICommentRepository> commentRepositoryMock = new Mock<ICommentRepository>();

            var postService = new PostService(postRepositoryMock.Object, userRepositoryMock.Object, commentRepositoryMock.Object);

            //Act
            await Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                var postUpdated = await postService.AddNewRating("123", 5);
                var postRate = postUpdated.Rating;
            });
        }

    }
}
