using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICardService
    {
        IDataResult<List<Card>> GetByCardNumber(string cardNumber);
        IDataResult<List<Card>> GetAll();
        IDataResult<Card> Get(Card card);
        IDataResult<Card> GetById(int carId);
        IResult IsCardExist(Card card);
        IResult Add(Card card);
        IResult Update(Card card);
        IResult Delete(Card card);
        IResult DeleteById(int cardId);
        IDataResult<List<Card>> GetAllCardByCustomerId(int customerId);
    }
}
