using TrainingAppAPI.ServiceModel.Response;

namespace TrainingAppAPI.DataModel.Interfaces
{
  public interface IPaymentRepository
  {
    Task<List<Card_ViewModel>> GetPaymentCardsAsync();
    Task<Card_ViewModel> GetPaymentCardAsync(int id);
    Task<bool> UpdatePaymentCardAsync(int id, Card_ViewModel cardItem);
    Task<bool> AddPaymentCardAsync(Card_ViewModel paymentDetail);
    Task<bool> DeletePaymentCardAsync(int id);
    Task<bool> IsPaymentCardExistAsync(int id);
  }
}
