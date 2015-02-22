using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GameFlow.Common
{
    public interface ICharacterDefinition
    {
        IReadOnlyDictionary<Card, int> InitialDeck { get; }
    }
    public abstract class CharacterDefinition:ICharacterDefinition
    {
        public IReadOnlyDictionary<Card, int> InitialDeck
        {
            get { return new ReadOnlyDictionary<Card, int>(MyCards); }
        }

        protected abstract Dictionary<Card, int> MyCards { get; }
    }
}