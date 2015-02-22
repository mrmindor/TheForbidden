using System;
using System.Collections.Generic;
using System.Linq;

namespace GameFlow.Common
{
    public class Game
    {
        public Card InPlacePurchase (IList<Card>availableCards, int i)
        {
            var card = availableCards[i];
            if (ReplaceCardSlot(i))
            {
                return card;
            }
            //no more cards to replace with...
            availableCards.RemoveAt(i);
            return card;
        }

        public Card SlidingPurchase(IList<Card> availableCards, int i)
        {
            var card = availableCards[i];
            availableCards.RemoveAt(i);
            FillCardPool();
            return card;
        }
        public Reserves ReserveCards { get; set; }
        public Deck DrawPile { get; set; }
        public List<Card> CardPool { get; set; }
        public List<Card> DiscardPile { get; set; }
        public List<Player> Players { get; set; }
        public int CardPoolSize { get; set; }

        private void Recycle(Deck d)
        {
            d.ShuffleIn(DiscardPile, ReserveCards.Any() ? ReserveCards.GetNext() : new List<Card>());
            DiscardPile.Clear();
        }

        public Game(CardSet cards, IEnumerable<ICharacterDefinition> characters)
        {
            DiscardPile = new List<Card>();
            CardPool = new List<Card>();
            ReserveCards = new Reserves(cards.C.Flatten(), cards.B.Flatten(), cards.A.Flatten(), cards.S.Flatten());
            Players = characters.Select(c => new Player(c)).ToList();
            var playersCards = characters.SelectMany(c => c.InitialDeck.Flatten())
                          .GroupBy(c => c)
                          .ToDictionary(g => g.Key, g => g.Count());
            var initialDeck = new Dictionary<Card, int>(cards.D);
            foreach (var playersCard in playersCards)
            {
                if(initialDeck.ContainsKey(playersCard.Key))
                {
                    initialDeck[playersCard.Key] = initialDeck[playersCard.Key] - playersCard.Value;
                }
            }
            DrawPile =new Deck(initialDeck.Flatten(),Recycle);

        }

        public Game()
        {
            ReserveCards = new Reserves();
            DrawPile = new Deck(new Card[] {},Recycle );
            CardPool = new List<Card>();
            DiscardPile = new List<Card>();
            Players = new List<Player>();

        }

        public void ExecuteTurn()
        {
            AdvanceCardPool();
            foreach (var player in Players)
            {
                player.ExecuteTurn(new CardPool(CardPool, InPlacePurchase));
            }
        }

        public void AdvanceCardPool()
        {
            if (CardPool.Any())
            {
                var discardCard = CardPool[0];
                DiscardPile.Add(discardCard);
                CardPool.RemoveAt(0);
            }
            FillCardPool();
        }

        private void FillCardPool()
        {
            while (CardPool.Count < CardPoolSize)
            {
                Console.WriteLine("Drawing Card for Cardpool.");
                if (!CardPool.DrawFrom(DrawPile))
                {
                    break;
                }
            }
        }

        public bool ReplaceCardSlot(int x)
        {
            if (x >= CardPoolSize) return false;
            var card = DrawPile.DrawWithRecycle();
            if (card == null) return false;
            CardPool[x] = card;
            return true;
        }

       

    }
}