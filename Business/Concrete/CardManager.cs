using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CardManager :ICardService
    {
        ICardDal _cardDal;
        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }

        public IResult Add(Card card)
        {
            _cardDal.Add(card);
            return new SuccessResult();
        }

        public IResult Delete(Card card)
        {
            _cardDal.Delete(card);
            return new SuccessResult();
        }

        public IDataResult<List<Card>> GetAll()
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll());
        }

        public IDataResult<List<Card>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll(c => c.CardNumber == cardNumber));
        }

        public IDataResult<Card> GetById(int cardId)
        {
            Card p = new Card();
            if (!_cardDal.GetAll().Any(x => x.CardId == cardId))
            {
                return new ErrorDataResult<Card>("NotExist" + "credit card");
            }
            p = _cardDal.GetAll().FirstOrDefault(x => x.CardId == cardId);
            return new SuccessDataResult<Card>(p);
        }
        public IDataResult<Card> Get(Card entity)
        {
            return new SuccessDataResult<Card>(_cardDal.Get(x => x.CardId == entity.CardId));
        }
        public IResult IsCardExist(Card card)
        {
            var result = _cardDal.Get(c => c.Name == card.Name && c.CardNumber == card.CardNumber && c.Cvv == card.Cvv);
            if (result == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult CheckIfCardIsExists(string cardNumber)
        {
            if (_cardDal.GetAll().Any(x => x.CardNumber == cardNumber))
            {
                return new ErrorResult("Card Already Exist");
            }
            return new SuccessResult();
        }
        public IResult Update(Card card)
        {
            _cardDal.Update(card);
            return new SuccessResult();
        }
        public IDataResult<List<Card>> GetAllCardByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll().Where(x => x.CustomerId == customerId).ToList());
        }
        public IResult DeleteById(int cardId)
        {
            var card = _cardDal.Get(x => x.CardId == cardId);
            _cardDal.Delete(card);
            return new SuccessResult(Messages.CardDeleted);
        }
    }
}
