using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using GameFlow.Common;
using GameFlow.SetA;
using NUnit.Framework;

namespace Test.SetA
{
    [TestFixture]
    public class CardsTest
    {
        [Test]
        public void CountCards()
        {
            var x = Cards.Set;
            var count = x.A.Concat(x.B).Concat(x.C).Concat(x.D).Concat(x.S).Sum(kv => kv.Value);
            Assert.That(count, Is.LessThan(120));
        }

        [Test]
        public void ShouldEqual()
        {
            var c1 = Cards.RankA.P1;
            var c2 = Cards.RankA.P1;
            var x = c1.Equals(c2);
            Assert.That(x, Is.True);
        }
        [Test]
        public void CostHistogram()
        {
            var set = Cards.Set;
            var allCosts = set.S.Flatten()
                .Concat(set.A.Flatten())
                .Concat(set.B.Flatten())
                .Concat(set.C.Flatten())
                .Concat(set.D.Flatten())
                .SelectMany(card => card.Costs.SelectMany(cost=>cost.Elements))
                .GroupBy(kv=>kv.Key).ToDictionary(g=>g.Key, g=>g.Sum(kv=> kv.Value));
            foreach (var allCost in allCosts.OrderBy(c=> c.Key))
            {
                Console.WriteLine("{0}:{1}",allCost.Key,allCost.Value);
            }
        }
    }
}
