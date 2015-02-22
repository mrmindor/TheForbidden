using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;

namespace GameFlow.Common
{
    public class Player
    {
        public IEnumerable<Card> Collection
        {
            get { return DrawPile.Contents.Concat(Hand).Concat(DiscardPile); }
        }
        public ICharacterDefinition Character { get; set; }
        public Deck DrawPile { get; set; }
        public List<Card> Hand { get; set; }
        public List<Card> PlayedCards { get; set; } 
        public List<Card> DiscardPile { get; set; }
        public int HandSize { get; set; }

        public Player() { }
        public Player(ICharacterDefinition character)
        {
            Character = character;
            PlayedCards = new List<Card>();
            DrawPile = new Deck(character.InitialDeck.Flatten(), Recycle);
            Hand = new List<Card>();
            DiscardPile = new List<Card>();
            HandSize = 5;
        }
        private void Recycle(Deck d)
        {
            d.ShuffleIn(DiscardPile);
            DiscardPile.Clear();
        } 

        public void ExecuteTurn(ICardPool pool)
        {
            Hand.DiscardTo(DiscardPile);
            PlayedCards.DiscardTo(DiscardPile);
            FillHand();
            while (Hand.Any())
            {
                var card = Hand[0];
                Hand.RemoveAt(0);
                card.Play(this, null, pool);
                PlayedCards.Add(card);
            }
            
            var availableFunds = PlayedCards.Select(c => c.EType).Concat(new []{Element.Free}).GroupBy(e => e).ToDictionary(g => g.Key, g => g.Count());
            DiscardPile.AddRange(pool.BuyAll(availableFunds));

            Console.WriteLine("Own {0} Cards:{1}", Collection.Count(),string.Join(", ", Collection.OrderBy(c=>c.CardId).Select(c=> c.ToString())));

        }

        public void FillHand()
        {
            while (Hand.Count() < HandSize)
            {
                Console.WriteLine("Drawing card to Hand.");
                if (!Hand.DrawFrom(DrawPile))
                {
                    return;
                }
            }
        }

        

    }
}