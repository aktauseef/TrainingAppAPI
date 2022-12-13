using Microsoft.EntityFrameworkCore;
using TrainingAppAPI.DataModel.Context;
using TrainingAppAPI.DataModel.Entities;
using TrainingAppAPI.DataModel.Interfaces;
using TrainingAppAPI.ServiceModel.Response;

namespace TrainingAppAPI.DataModel.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly TrainingAppAPIContext _dbContext;
        public PaymentRepository(TrainingAppAPIContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> DeletePaymentCardAsync(int id)
        {
            var card = await _dbContext.CardItem.FindAsync(id);
            if (card == null)
            {
                return false;
            }
            _dbContext.CardItem.Remove(card);
            return await _dbContext.SaveChangesAsync() == 1 ? true : false;
        }

        public async Task<Card_ViewModel> GetPaymentCardAsync(int id)
        {
            var result = await _dbContext.CardItem.AsNoTracking().Where(x => x.CardId == id).Select(result => new Card_ViewModel
            {
                CardId = result.CardId,
                CardOwnerName = result.CardOwnerName,
                CardNumber = result.CardNumber,
                SecurityCode = result.SecurityCode,
                ExpirationDate = result.ExpirationDate
            }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Card_ViewModel>> GetPaymentCardsAsync()
        {
            var result = await _dbContext.CardItem.AsNoTracking().Select(result => new Card_ViewModel
            {
                CardId = result.CardId,
                CardOwnerName = result.CardOwnerName,
                CardNumber = result.CardNumber,
                SecurityCode = result.SecurityCode,
                ExpirationDate = result.ExpirationDate
            }).ToListAsync();
            return result;
        }

        public async Task<bool> IsPaymentCardExistAsync(int id)
        {
            return await _dbContext.CardItem.AsNoTracking().AnyAsync(item => item.CardId == id);
        }

        public async Task<bool> AddPaymentCardAsync(Card_ViewModel paymentDetail)
        {
            _dbContext.CardItem.Add(new CardItem
            {
                CardNumber = paymentDetail.CardNumber,
                CardOwnerName = paymentDetail.CardOwnerName,
                SecurityCode = paymentDetail.SecurityCode,
                ExpirationDate = paymentDetail.ExpirationDate,
            });
            return await _dbContext.SaveChangesAsync() == 1 ? true : false;
        }

        public async Task<bool> UpdatePaymentCardAsync(int id, Card_ViewModel cardItem)
        {

            var data = _dbContext.CardItem.FirstOrDefault(x => x.CardId == id);
            if (data != null)
            {
                data.CardNumber = cardItem.CardNumber;
                data.CardOwnerName = cardItem.CardOwnerName;
                data.SecurityCode = cardItem.SecurityCode;
                data.ExpirationDate = cardItem.ExpirationDate;
                return await _dbContext.SaveChangesAsync() == 1 ? true : false;
            }
            return false;

        }
    }
}
