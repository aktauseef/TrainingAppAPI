using TrainingAppAPI.ServiceModel.Response;
using Xunit;

namespace TrainingAppAPI.UnitTests.Repositories
{
    public class PaymentRepositoryTest : BaseServiceSetup
    {

        [Fact]
        public void AddPaymentCardAsync_WhenValidRequest_ReturnsTrue()
        {
            var card = new Card_ViewModel
            {
                CardId = 3,
                CardNumber = "62441641654165",
                CardOwnerName = "abc",
                SecurityCode = "123",
                ExpirationDate = "2201"
            };
            bool result = _paymentRepoService.AddPaymentCardAsync(card).Result;
            Assert.True(result);
        }

        [Fact]
        public void DeletePaymentCardAsync_WhenValidRequest_ReturnsTrue()
        {
            bool result = _paymentRepoService.DeletePaymentCardAsync(1).Result;
            Assert.True(result);
        }

        [Fact]
        public void GetPaymentCardAsync_WhenValidRequest_ReturnsCard()
        {
            var result = _paymentRepoService.GetPaymentCardAsync(1).Result;
            Assert.Equal("card1", result.CardOwnerName);
        }

        [Fact]
        public void GetPaymentCardsAsync_WhenValidRequest_ReturnsListOfCards()
        {
            var result = _paymentRepoService.GetPaymentCardsAsync().Result;
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void IsPaymentCardExistAsync_WhenValidRequest_ReturnsTrue()
        {
            var result = _paymentRepoService.IsPaymentCardExistAsync(1).Result;
            Assert.True(result);
        }

        [Fact]
        public void UpdatePaymentCardAsync_WhenValidRequest_ReturnsTrue()
        {
            var card = new Card_ViewModel
            {
                CardId = 1,
                CardNumber = "62441641654165",
                CardOwnerName = "abc",
                SecurityCode = "123",
                ExpirationDate = "2201"
            };
            var result = _paymentRepoService.UpdatePaymentCardAsync(1,card).Result;
            Assert.True(result);
        }

    }

}
