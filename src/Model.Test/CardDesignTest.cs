using Model;
using NUnit.Framework;

namespace Model.Test
{
    [TestFixture]
    public class CardDesignTest
    {
        [Test]
        public void ShouldLoadCards()
        {
            var dao = new CardDesignEntities();
            var x = dao.AlchemyCards;
            var y = dao.AlchemyElements;
            Assert.That(y,Is.Not.Empty);
        }
    }
}
