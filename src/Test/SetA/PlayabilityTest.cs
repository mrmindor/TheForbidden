using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFlow.Common;
using GameFlow;
using GameFlow.SetA;
using NUnit.Framework;

namespace Test.SetA
{
    [TestFixture]
    public class PlayabilityTest
    {
        [Test]
        public void Test()
        {
            var characters = new List<ICharacterDefinition> 
                             {
                                  Characters.Bob, Characters.Amos
                             };
            var game = new Game(Cards.Set, characters){CardPoolSize = 5};
            for (int i = 0; i < 30; i++)
            {
                game.ExecuteTurn();
            }

        }
    }
}
