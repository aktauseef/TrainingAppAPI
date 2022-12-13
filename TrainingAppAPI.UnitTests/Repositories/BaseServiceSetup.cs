using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TrainingAppAPI.DataModel.Context;
using TrainingAppAPI.DataModel.Entities;
using TrainingAppAPI.DataModel.Repositories;

namespace TrainingAppAPI.UnitTests.Repositories
{
    public class BaseServiceSetup
    {
        protected PaymentRepository _paymentRepoService;
        private TrainingAppAPIContext _mockContext;
        public BaseServiceSetup()
        {
            var options = new DbContextOptionsBuilder<TrainingAppAPIContext>()    //create inmemory db
                        .UseInMemoryDatabase(databaseName: "TrainingAppAPIFakeDb").Options;
            _mockContext = new TrainingAppAPIContext(options);

            #region CardItems
            _mockContext.CardItem.RemoveRange(_mockContext.CardItem);
            var cardItems = new List<CardItem> {
                new CardItem
                {
                    CardId = 1,
                CardNumber = "111111111111",
                CardOwnerName = "card1",
                SecurityCode = "123",
                ExpirationDate = "0225"
                },
                new CardItem
                {
                    CardId = 2,
                CardNumber = "2222222222222",
                CardOwnerName = "card2",
                SecurityCode = "234",
                ExpirationDate = "0125"
                }
            }.ToList();
            _mockContext.CardItem.AddRange(cardItems);       //Add records in dbSet<CardItem> 
            #endregion

            _mockContext.SaveChanges();                      //save db
            _paymentRepoService = new PaymentRepository(_mockContext);   //create service instance

        }

    }
}
