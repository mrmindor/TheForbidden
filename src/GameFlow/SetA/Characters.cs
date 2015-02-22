using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFlow.Common;

namespace GameFlow.SetA
{
    public static class Characters
    {
        private class BobDefinition : CharacterDefinition
        {
            protected override Dictionary<Card, int> MyCards
            {
                get
                {
                    return new Dictionary<Card, int>
                           {
                               {Cards.RankD.A,2},{Cards.RankD.B,2},{Cards.RankD.C,2},
                               {Cards.RankD.D,2},{Cards.RankD.E,1},{Cards.RankD.F,1}
                           };
                }
            }

           
        }
        private class SueDefinition : CharacterDefinition
        {
            protected override Dictionary<Card, int> MyCards
            {
                get
                {
                    return new Dictionary<Card, int>
                           {
                               {Cards.RankD.A,1},{Cards.RankD.B,2},{Cards.RankD.C,2},
                               {Cards.RankD.D,2},{Cards.RankD.E,2},{Cards.RankD.F,1}
                           };
                }
            }

           
        }
        private class MikeDefinition : CharacterDefinition
        {
            protected override Dictionary<Card, int> MyCards
            {
                get
                {
                    return new Dictionary<Card, int>
                           {
                               {Cards.RankD.A,1},{Cards.RankD.B,1},{Cards.RankD.C,2},
                               {Cards.RankD.D,2},{Cards.RankD.E,2},{Cards.RankD.F,2}
                           };
                }
            }
        }
        private class LisaDefinition : CharacterDefinition
        {
            protected override Dictionary<Card, int> MyCards
            {
                get
                {
                    return new Dictionary<Card, int>
                           {
                               {Cards.RankD.A,2},{Cards.RankD.B,1},{Cards.RankD.C,1},
                               {Cards.RankD.D,2},{Cards.RankD.E,2},{Cards.RankD.F,2}
                           };
                }
            }
        }
        private class LarryDefinition : CharacterDefinition
        {
            protected override Dictionary<Card, int> MyCards
            {
                get
                {
                    return new Dictionary<Card, int>
                           {
                               {Cards.RankD.A,2},{Cards.RankD.B,2},{Cards.RankD.C,1},
                               {Cards.RankD.D,1},{Cards.RankD.E,2},{Cards.RankD.F,2}
                           };
                }
            }
        }
        private class AmosDefinition : CharacterDefinition
        {
            protected override Dictionary<Card, int> MyCards
            {
                get
                {
                    return new Dictionary<Card, int>
                           {
                               {Cards.RankD.A,2},{Cards.RankD.B,2},{Cards.RankD.C,2},
                               {Cards.RankD.D,1},{Cards.RankD.E,1},{Cards.RankD.F,2}
                           };
                }
            }
        }

        public static ICharacterDefinition Bob { get { return new BobDefinition();} }
        public static ICharacterDefinition Sue { get { return new SueDefinition();} }
        public static ICharacterDefinition Mike { get { return new MikeDefinition();} }
        public static ICharacterDefinition Lisa { get { return new LisaDefinition();} }
        public static ICharacterDefinition Larry { get { return new LarryDefinition();} }
        public static ICharacterDefinition Amos { get { return new AmosDefinition();} }
    }
}
