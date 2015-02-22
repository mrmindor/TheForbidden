using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFlow.SetA;
using GameFlow;
using GameFlow.Common;
using NUnit.Framework;

namespace Test.Common
{
    [TestFixture]
    public class CardTest
    {
        [Test]
        public void ShouldCopyCard()
        {
            var original = Cards.RankD.A;
            var copy = original.Clone();
            Assert.That(original.EType, Is.EqualTo(copy.EType));
            Assert.That(original.Costs, Is.EqualTo(copy.Costs));
            var x = original.Costs.Equals(copy.Costs);
            Assert.That(x, Is.True);
        }
    }
}
