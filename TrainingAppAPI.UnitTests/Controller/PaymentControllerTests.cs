using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using TrainingAppAPI.Controllers;
using TrainingAppAPI.DataModel.Context;
using TrainingAppAPI.DataModel.Interfaces;
using TrainingAppAPI.ServiceModel.Response;
using Xunit;

namespace TrainingAppAPI.UnitTests.Controller
{
    public class PaymentControllerTests
    {
        private readonly PaymentController _controller;
        private readonly Mock<IPaymentRepository> _repositoryMock;
        private readonly DbContextOptions<TrainingAppAPIContext> _dbContextOptions;
        private readonly TrainingAppAPIContext _dbContext;

        public PaymentControllerTests()
        {
            _repositoryMock = new Mock<IPaymentRepository>();
            _controller = new PaymentController(_repositoryMock.Object);
            _dbContextOptions = new DbContextOptions<TrainingAppAPIContext>();
            _dbContext = new TrainingAppAPIContext(_dbContextOptions);
        }

        [Fact]
        public void GetPaymentCardsAsync_WhenValidRequest_ReturnsDataOnOkResult()
        {
            //Arrange
            var card = new List<Card_ViewModel>
            {
                new Card_ViewModel{
                    CardId = 1,
                    CardNumber = "62441641654165",
                    CardOwnerName = "TestUser",
                    SecurityCode= "123",
                    ExpirationDate="2201"
                }
            }.ToList();
            _repositoryMock.Setup(x => x.GetPaymentCardsAsync().Result).Returns(card);

            //Act
            var result = _controller.GetPaymentCardsAsync();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetPaymentCardAsync_WhenValidRequest_ReturnsDataOnOkResult()
        {
            var card = new Card_ViewModel
            {
                CardId = 1,
                CardNumber = "62441641654165",
                CardOwnerName = "TestUser",
                SecurityCode = "123",
                ExpirationDate = "2201"
            };
            _repositoryMock.Setup(x => x.GetPaymentCardAsync(1).Result).Returns(card);

            var result = _controller.GetPaymentCardAsync(1);

            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact]
        public void AddCardAsync_WhenValidRequest_ReturnsTrueOkResult()
        {
            var card = new Card_ViewModel
            {
                CardId = 1,
                CardNumber = "62441641654165",
                CardOwnerName = "TestUser",
                SecurityCode = "123",
                ExpirationDate = "2201"
            };
            _repositoryMock.Setup(x => x.AddPaymentCardAsync(card).Result).Returns(true);
            var result=_controller.AddCardAsync(card);
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void UpdateCardAsync_WhenValidRequest_ReturnsTrueOkResult()
        {
            var card = new Card_ViewModel
            {
                CardId = 1,
                CardNumber = "62441641654165",
                CardOwnerName = "TestUser",
                SecurityCode = "123",
                ExpirationDate = "2201"
            };
            _repositoryMock.Setup(x => x.UpdatePaymentCardAsync(1,card).Result).Returns(true);
            var result = _controller.UpdateCardAsync(1,card);
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void DeletePaymentCardAsync_WhenValidRequest_ReturnsTrueOkResult()
        {
            _repositoryMock.Setup(x => x.DeletePaymentCardAsync(1).Result).Returns(true);
            var result = _controller.DeletePaymentCardAsync(1);
            Assert.IsType<OkObjectResult>(result.Result);
        }

    }
}
