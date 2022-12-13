using Microsoft.AspNetCore.Mvc;
using TrainingAppAPI.DataModel.Interfaces;
using TrainingAppAPI.ServiceModel.Response;

namespace TrainingAppAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PaymentController : ControllerBase
  {
    public readonly IPaymentRepository _repository;
    public PaymentController(IPaymentRepository repository)
    {
      _repository = repository;
    }

    [HttpGet("GetCards")]
    public async Task<ActionResult> GetPaymentCardsAsync()
    {
      var cardItems=await _repository.GetPaymentCardsAsync();
      if (cardItems == null || cardItems.Count()==0) { return NotFound(); }
      return Ok(cardItems);
    }

    [HttpGet("GetCard/{id}")]
    public async Task<ActionResult> GetPaymentCardAsync(int id)
    {
      var cardItem = await _repository.GetPaymentCardAsync(id);
      if (cardItem==null) { return NotFound(); }
      return Ok(cardItem);
    }

    [HttpPost("AddCard")]
    public async Task<ActionResult> AddCardAsync(Card_ViewModel card)
    {
      bool result=await _repository.AddPaymentCardAsync(card);
      if (!result) { return BadRequest(); }
      return Ok(result);
    }

    [HttpPut("UpdateCard/{id}")]
    public async Task<ActionResult> UpdateCardAsync(int id,Card_ViewModel card)
    {
      if (id != card.CardId)
      {
        return BadRequest();
      }
      bool result=await _repository.UpdatePaymentCardAsync(id,card);
      if (!result) { return BadRequest(); }
      return Ok(result);
    }

    [HttpDelete("DeleteCard/{id}")]
    public async Task<ActionResult> DeletePaymentCardAsync(int id)
    {
      bool result =await _repository.DeletePaymentCardAsync(id);
      if (!result) { return BadRequest(); }
      return Ok(result);
    }

  }
}
