using System;
using System.Collections.Generic;
using System.Linq;

namespace GameFlow.Common
{
    public static class Shuffler
    {
        private static readonly Random Random = new Random();

        public static IEnumerable<Card> ShuffleWith(this IEnumerable<Card> pile, params IEnumerable<Card>[] otherPiles)
        {
            return otherPiles.SelectMany(p => p).Concat(pile).Shuffle();
        }

        public static IEnumerable<Card> Shuffle(this IEnumerable<Card> pile)
        {
            return pile.OrderBy(c => Random.Next());
        }

        public static bool DrawFrom(this List<Card> destination, Deck source)
        {
            var card = source.DrawWithRecycle();
            if (card == null) return false;
            destination.Add(card);
            return true;
        }

        public static void DiscardTo(this List<Card> source, List<Card> destination)
        {
            destination.AddRange(source);
            source.Clear();
        }


        public static IEnumerable<Card> Flatten(this IReadOnlyDictionary<Card, int> cards)
        {
            foreach (var card in cards)
            {
                for (int i = 0; i < card.Value; i++)
                {
                    yield return card.Key.Clone();
                }
            }
        }
        //public static T Clone<T>(this T source)
        //{
        //    var serialized = JsonConvert.SerializeObject(source);
        //    return JsonConvert.DeserializeObject<T>(serialized);
        //}
        
    }
}