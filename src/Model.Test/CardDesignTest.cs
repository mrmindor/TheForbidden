using Model;
using NUnit.Framework;
using System.Data;
using System.Linq;

namespace Model.Test
{
    [TestFixture]
    public class CardDesignTest
    {
        [Test]
        public void ShouldLoadCards()
        {
            //System.Data.SqlClient
            var dao = new CardDesignEntities();
            var x = dao.AlchemyCards.ToList();
            var y = dao.AlchemyElements.ToList();
            Assert.That(y,Is.Not.Empty);
        }
    }
}
