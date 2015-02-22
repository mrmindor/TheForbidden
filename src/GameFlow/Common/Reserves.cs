using System.Collections.Generic;
using System.Linq;

namespace GameFlow.Common
{
    public class Reserves
    {
        private Queue<IEnumerable<Card>> Cards { get; set; }

        public Reserves(params IEnumerable<Card>[] cards)
        {
            Cards = new Queue<IEnumerable<Card>>(cards);
        }

        public bool Any()
        {
            return Cards.Any();
        }

        public IEnumerable<Card> GetNext()
        {
            return Cards.Dequeue();
        }
    }
}