using System.Collections.Generic;
using GameFlow.Common;
using NUnit.Framework;

namespace Test.Common
{
    [TestFixture]
    public class CostTest
    {
        [Test]
        public void ShouldReturnTrueIfCanPayCost()
        {
            var cost = new Cost(Element.A, Element.B, Element.B);
            var funds = new Dictionary<Element, int>
            {
                {Element.A, 2},
                {Element.B, 2}
            };
            var result = cost.CanAfford(funds);
            Assert.That(result,Is.True);
        }

        [Test]
        public void ShouldDeductCostFromFunds()
        {
            var cost = new Cost(Element.A, Element.B, Element.B);
            var funds = new Dictionary<Element, int>
            {
                {Element.A, 2},
                {Element.E, 3},
                {Element.B, 2}
            };
            var result = cost.PayWith(funds);
            Assert.That(result, Is.True);
            Assert.That(funds.ContainsKey(Element.A), Is.True);
            Assert.That(funds[Element.A], Is.EqualTo(1));
            Assert.That(funds.ContainsKey(Element.B), Is.False );
            Assert.That(funds.ContainsKey(Element.E), Is.True);
            Assert.That(funds[Element.E], Is.EqualTo(3));
        }
    }
}
