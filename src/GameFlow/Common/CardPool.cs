using System;
using System.Collections.Generic;
using System.Linq;


namespace GameFlow.Common
{
    public delegate Card PurchaseCard(IList<Card> availableCards, int index);

    public interface IGameBoard
    {
        ICardPool CardPool { get; }
        IList<Card> DiscardPile { get; }
        Deck DrawPile { get; }
        IReadOnlyList<Player> OtherPlayers { get; }
    }
    public interface ICardPool
    {
        IEnumerable<Card> BuyAll(Dictionary<Element, int> available);
        Card FreeCard();
        
    }
    public class CardPool:ICardPool
    {

        private readonly IList<Card> _availableCards;
        private readonly PurchaseCard _replaceAction;

        public CardPool(IList<Card> card, PurchaseCard replacePurchase)
        {
            _availableCards = card;
            _replaceAction = replacePurchase;
        }

        public Card FreeCard()
        {
            var card = _availableCards[0];
            _replaceAction(_availableCards, 0);
            return card;
        }
        public IEnumerable<Card> BuyAll(Dictionary<Element, int> available)
        {
            while (available.Select(kv=>kv.Value).Sum() > 0)
            {
                var purchase = TryBuyAnyCard(available);
                if (purchase == null)
                {
                    yield break;
                    
                }
                Console.WriteLine("Bought: {0}",purchase);
                yield return purchase;
               
            }
        }

        private Card TryBuyAnyCard(Dictionary<Element, int> availableFunds)
        {
            for (var i = 0; i < _availableCards.Count(); i++)
            {
                var affordableCosts =
                    _availableCards[i].Costs.Where(
                        cost =>
                            cost.CanAfford(availableFunds)).ToList();
                if (!affordableCosts.Any()) continue;
                var card = _availableCards[i];
                _replaceAction(_availableCards, i);
                affordableCosts.First().PayWith(availableFunds);
                return card;
            }
            return null;
        }


    }
}
