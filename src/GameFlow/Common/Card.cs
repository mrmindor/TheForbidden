using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace GameFlow.Common
{
    public enum Rank
    {
        D=0,
        C=1,
        B=2,
        A=3,
        S=4
    }
    [DebuggerDisplay("{EType} Id={CardId}",Name = "Card")]
    public class Card : IEquatable<Card>
    {
        public int CardId { get; private set; }
        

        private Card() { }
        public Card Clone()
        {
            return new Card
            {
                CardId = CardId,
                EType = EType,
                Abilities = Abilities,
                Costs = Costs
            };
        }
        public IReadOnlyList<Cost> Costs { get; set; }
        public Element EType { get; private set; }
        private CardAbility Abilities { get; set; }
        public Card(int id, Element type, CardAbility abilities, params Cost[] costs)
        {
            CardId = id;
            EType = type;
            Abilities = abilities;
            Costs = costs.ToList();
        }

        public Card(int id, Element type, params Cost[] costs):this(id,type, CardAbilities.NoOp, costs)
        {
            
        }

        public void Play(Player player1, Player player2, ICardPool pool)
        {
            Abilities(player1, player2, pool);
        }

        public static bool operator ==(Card left, Card right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (ReferenceEquals(right, null)) return false;
            return !ReferenceEquals(left, null) && left.Equals(right);
        }

        public static bool operator !=(Card left, Card right)
        {
            return !(left == right);
        }

        public bool Equals(Card other)
        {

            return !ReferenceEquals(other, null) && CardId == other.CardId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return CardId;
            }
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((Card)obj);
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}", EType, CardId);
        }
    }
}