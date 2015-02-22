using System;
using System.Collections.Generic;
using System.Linq;

namespace GameFlow.Common
{
    public class Cost:IEquatable<Cost>
    {
        public IReadOnlyDictionary<Element, int> Elements { get; set; }
        public Cost(params Element[] elements){
            Elements = elements.GroupBy(e=> e).ToDictionary(e=> e.Key,e=>e.Count() );
        }

        public bool CanAfford(Dictionary<Element, int> funds)
        {
            return Elements.All(e => funds.ContainsKey(e.Key) && funds[e.Key] >= e.Value);
        }

        public bool PayWith(Dictionary<Element, int> funds)
        {
            if (!CanAfford(funds)) return false;
            foreach (var element in Elements)
            {
                funds[element.Key] = funds[element.Key] - element.Value;
                if (funds[element.Key] == 0)
                {
                    funds.Remove(element.Key);
                }
            }
            return true;
        }

        public bool Equals(Cost other)
        {
            return Elements.Count == other.Elements.Count 
                && Elements.All(e => other.Elements.ContainsKey(e.Key) && other.Elements[e.Key] == e.Value);
        }

        public static bool operator ==(Cost left, Cost right)
        {
            return !ReferenceEquals(null,left) && left.Equals(right);
        }

        public static bool operator !=(Cost left, Cost right)
        {
            return !(left == right);
        }
    }
}