using System;
using System.Collections.Generic;
using System.Linq;

namespace GameFlow.Common
{
    public class Deck
    {
        private readonly Action<Deck> _recycle;
        private List<Card> _cards;

        public Deck(IEnumerable<Card> cards, Action<Deck> recycle)
        {
            _recycle = recycle;
            _cards = cards.Shuffle().ToList();
        }

        public void Shuffle()
        {
            _cards = _cards.Shuffle().ToList();
        }

        public void ShuffleIn(params IEnumerable<Card>[] cards)
        {
            _cards = _cards.ShuffleWith(cards).ToList();

        }

        public bool Any()
        {
            return _cards.Any();
        }

        public Card DrawWithRecycle()
        {
            if (!_cards.Any())
            {
                _recycle(this);
            }
            return _cards.Any() ? Draw() : null;
        }
        private Card Draw()
        {
            var card = _cards[0];
            _cards.RemoveAt(0);
            Console.WriteLine("Drew: {0}", card);
            return card;
        }

        public IEnumerable<Card> Contents
        {
            get { return _cards.ToList(); }
        }

    }
}