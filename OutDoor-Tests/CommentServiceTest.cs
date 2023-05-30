using OutDoor_Models.Models;
using OutDoor_Models.Repository;
using OutDoor_Models.Repositorys;
using OutDoor_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Tests
{
    public class CommentServiceTest
    {
        [Fact]
        public async void AddNewCommentToPostTest()
        {

            //Arrange
            Moq.Mock<ICommentRepository> commentRepositoryMock = new Moq.Mock<ICommentRepository>();
            commentRepositoryMock.Setup(x => x.createNewComent(It.IsAny<CreateCommentRequestModel>()).Result).Returns(new CommentModel()
            {
                Id = "123",
                Image = "img",
                PostId = "123",
                UserId = "1",
                Review = "rv",
                CreatedAt = DateTime.Today,
                
            });
            Moq.Mock<IUserRepository> userRepositoryMock = new Moq.Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetById(It.Is<string>(x => x == "1")).Result).Returns(new UserModel()
            {
                UserType = "client"
            });
            var commentService = new CommentService(commentRepositoryMock.Object, userRepositoryMock.Object);

            var createCommentReq = new CreateCommentRequestModel()
            {
                UserId = "1",
                Image = "img",
                Review = "rv",
                PostId = "1",
                rating = 5
            };

            //Act
            var commentCreated = await commentService.postNewComment(createCommentReq);



            Assert.Equal("1", createCommentReq.UserId);
            Assert.Equal("img", createCommentReq.Image);
            Assert.Equal("rv", createCommentReq.Review);
            Assert.Equal("1", createCommentReq.PostId);
            Assert.Equal(5, createCommentReq.rating);

            Assert.NotNull(commentCreated);
            Assert.Equal("123", commentCreated.Id);
            Assert.Equal("img", commentCreated.Image);
            Assert.Equal("123", commentCreated.PostId);
            Assert.Equal("1", commentCreated.UserId);
            Assert.Equal("rv", commentCreated.Review);
            Assert.Equal(DateTime.Today, commentCreated.CreatedAt);
        }


        [Fact]
        public async void AddNewCommentToPostWithoutClientAccountTest()
        {

            //Arrange
            Moq.Mock<ICommentRepository> commentRepositoryMock = new Moq.Mock<ICommentRepository>();
            Moq.Mock<IUserRepository> userRepositoryMock = new Moq.Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetById(It.Is<string>(x => x == "1")).Result).Returns(new UserModel()
            {
                UserType = "provider"
            });
            var commentService = new CommentService(commentRepositoryMock.Object, userRepositoryMock.Object);

            //Act then Assert
            await Assert.ThrowsAsync<ServiceException>(async () =>
            {
                await commentService.postNewComment(new CreateCommentRequestModel()
                {
                    UserId = "1"
                });
            });
        }
    }
}
