using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFlow.Common;

namespace GameFlow.SetA
{

    public static class Cards
    {
        public static CardSet Set
        {
            get
            {
                return new CardSet
                {
                    D = new Dictionary<Card,int>{{RankD.A,4},{RankD.B, 4},{RankD.C,4},{RankD.D,4},{RankD.E,4},{RankD.F,4}},
                    C = new Dictionary<Card,int>{{RankC.G1,4},{RankC.G2,4},{RankC.H1,4},{RankC.H2,4},{RankC.I1,4},{RankC.I2,4},{RankC.J1,4},{RankC.J2,4}},
                    B = new Dictionary<Card,int>{{RankB.K1,2},{RankB.K2,2},{RankB.K3,2},{RankB.L1,2},{RankB.L2,2},{RankB.L3,2},{RankB.M1,2},{RankB.M2,2},{RankB.M3,2},{RankB.N1,2},{RankB.N2,2},{RankB.N3,2},{RankB.O1,2},{RankB.O2,2},{RankB.O3,2}},
                    A = new Dictionary<Card,int>{{RankA.P1,2},{RankA.P2,2},{RankA.Q1,2},{RankA.Q2,2},{RankA.R1,2},{RankA.R2,2},{RankA.S1,2},{RankA.S2,2},{RankA.T1,2},{RankA.T2,2},},
                    S = new Dictionary<Card,int>{{RankS.U1,1},{RankS.U2,1},{RankS.V1,1},{RankS.V2,1},{RankS.W1,1},{RankS.W2,1},{RankS.X1,1},{RankS.X2,1},{RankS.Y1,1},{RankS.Y2,1},{RankS.Z1,1},{RankS.Z2,1}}
                };
            }
        }


        public static class RankD 
        {
            public static Card A { get { return new Card(1,Element.A, new Cost(Element.Free)); } }
            public static Card B { get { return new Card(2,Element.B, new Cost(Element.Free)); } }
            public static Card C { get { return new Card(3,Element.C, new Cost(Element.Free)); } }
            public static Card D { get { return new Card(4,Element.D, new Cost(Element.Free)); } }
            public static Card E { get { return new Card(5,Element.E, new Cost(Element.Free)); } }
            public static Card F { get { return new Card(6,Element.F, new Cost(Element.Free)); } }
        }
        public static class RankC 
        {
            public static Card G1 { get { return new Card(7,Element.G, new Cost(Element.A, Element.B), new Cost(Element.A, Element.F)); } }
            public static Card G2 { get { return new Card(8,Element.G, CardAbilities.DrawACard, new Cost(Element.A, Element.C), new Cost(Element.A, Element.E)); } }
            public static Card H1 { get { return new Card(9,Element.H, new Cost(Element.B, Element.C), new Cost(Element.C, Element.D)); } }
            public static Card H2 { get { return new Card(10,Element.H, CardAbilities.DrawACard,new Cost(Element.C, Element.E)); } }
            public static Card I1 { get { return new Card(11,Element.I, new Cost(Element.A, Element.D),new Cost(Element.B, Element.D)); } }
            public static Card I2 { get { return new Card(12,Element.I, CardAbilities.DrawACard, new Cost(Element.B, Element.E), new Cost(Element.B, Element.F)); } }
            public static Card J1 { get { return new Card(13,Element.J, new Cost(Element.C, Element.F),new Cost(Element.D, Element.E)); } }
            public static Card J2 { get { return new Card(14,Element.J, CardAbilities.DrawACard, new Cost(Element.D, Element.F), new Cost(Element.E, Element.F)); } }
            
            //Cost(Element.A, Element.B)
            //Cost(Element.A, Element.C)
            //Cost(Element.A, Element.D)
            //Cost(Element.A, Element.E)
            //Cost(Element.A, Element.F)
            //Cost(Element.B, Element.C)
            //Cost(Element.B, Element.D)
            //new Cost(Element.B, Element.E), new Cost(Element.B, Element.F)
            //Cost(Element.C, Element.D)
            //Cost(Element.C, Element.E)
            //new Cost(Element.C, Element.F),new Cost(Element.D, Element.E)
            //new Cost(Element.D, Element.F),new Cost(Element.E, Element.F)
        }

        public static class RankB
        {
            //new Cost(Element.A,Element.C,Element.E)
            //new Cost(Element.B,Element.D,Element.F)
            //new Cost(Element.C,Element.E,Element.A)
            //new Cost(Element.D,Element.F,Element.B)
            //new Cost(Element.E,Element.A,Element.C)
            //new Cost(Element.F,Element.B,Element.D)

            //new Cost(Element.G,Element.G),
            //new Cost(Element.G,Element.H),
              
            //new Cost(Element.G,Element.I), 
            //new Cost(Element.G,Element.J),
            
            //new Cost(Element.H,Element.H), 
            //new Cost(Element.H,Element.I), 
            
            //new Cost(Element.H,Element.J),
            //new Cost(Element.I,Element.I), 
            
            //new Cost(Element.I,Element.J)
            //new Cost(Element.J,Element.J)
            public static Card K1 { get { return new Card(15,Element.K, new Cost(Element.G, Element.G)); } }
            public static Card K2 { get { return new Card(16,Element.K, new Cost(Element.G, Element.H)); } }
            public static Card K3 { get { return new Card(17,Element.K, new Cost(Element.A, Element.C, Element.E)); } }
            public static Card L1 { get { return new Card(18,Element.L, new Cost(Element.G, Element.I)); } }
            public static Card L2 { get { return new Card(19,Element.L, new Cost(Element.G, Element.J)); } }
            public static Card L3 { get { return new Card(20,Element.L, new Cost(Element.B, Element.D, Element.F)); } }
            public static Card M1 { get { return new Card(21,Element.M, new Cost(Element.H, Element.H)); } }
            public static Card M2 { get { return new Card(22,Element.M, new Cost(Element.H, Element.I)); } }
            public static Card M3 { get { return new Card(23,Element.M, new Cost(Element.C, Element.E, Element.A)); } }
            public static Card N1 { get { return new Card(24,Element.N, new Cost(Element.H, Element.J)); } }
            public static Card N2 { get { return new Card(25,Element.N, new Cost(Element.I, Element.I)); } }
            public static Card N3 { get { return new Card(26,Element.N, new Cost(Element.D, Element.F, Element.B)); } }
            public static Card O1 { get { return new Card(27,Element.O, new Cost(Element.I, Element.J)); } }
            public static Card O2 { get { return new Card(28,Element.O, new Cost(Element.J, Element.J)); } }
            public static Card O3 { get { return new Card(29,Element.O, new Cost(Element.E, Element.A, Element.C)); } }
        }

        public static class RankA
        {
            //, new Cost(Element.K,Element.K)
            //, new Cost(Element.K,Element.L)
            //, new Cost(Element.K,Element.M)
            //, new Cost(Element.K,Element.N)
            //, new Cost(Element.K,Element.O)
            //, new Cost(Element.L,Element.L)  
            //, new Cost(Element.L,Element.M) 
            //, new Cost(Element.L,Element.N) 
            //, new Cost(Element.L,Element.O) 
            //, new Cost(Element.M,Element.M) 
            //, new Cost(Element.M,Element.N)
            //, new Cost(Element.M,Element.O)
            //, new Cost(Element.N,Element.N)  
            //, new Cost(Element.N,Element.O) 
            //, new Cost(Element.O,Element.O)
            public static Card P1 { get { return new Card(31,Element.P, new Cost(Element.K, Element.K), new Cost(Element.M, Element.N)); } }
            public static Card P2 { get { return new Card(32,Element.P, new Cost(Element.K, Element.L), new Cost(Element.M, Element.O)); } }
            public static Card Q1 { get { return new Card(33,Element.Q, new Cost(Element.K, Element.M), new Cost(Element.N, Element.N)); } }
            public static Card Q2 { get { return new Card(34,Element.Q, new Cost(Element.K, Element.N), new Cost(Element.N, Element.O)); } }
            public static Card R1 { get { return new Card(35,Element.R, new Cost(Element.K, Element.O), new Cost(Element.O, Element.O)); } }
            public static Card R2 { get { return new Card(36,Element.R, new Cost(Element.L, Element.L)); } }
            public static Card S1 { get { return new Card(37,Element.S, new Cost(Element.L, Element.M)); } }
            public static Card S2 { get { return new Card(38,Element.S, new Cost(Element.L, Element.N)); } }
            public static Card T1 { get { return new Card(39,Element.T, new Cost(Element.L, Element.O)); } }
            public static Card T2 { get { return new Card(40,Element.T, new Cost(Element.M, Element.M)); } }
                                                                   
            //,U,V
            //W,X,Y,Z
        }

        public static class RankS
        {
            public static Card U1 { get { return new Card(41,Element.U); } }
            public static Card U2 { get { return new Card(42,Element.U); } }
            public static Card V1 { get { return new Card(43,Element.V); } }
            public static Card V2 { get { return new Card(44,Element.V); } }
            public static Card W1 { get { return new Card(45,Element.W); } }
            public static Card W2 { get { return new Card(46,Element.W); } }
            public static Card X1 { get { return new Card(47,Element.X); } }
            public static Card X2 { get { return new Card(48,Element.X); } }
            public static Card Y1 { get { return new Card(49,Element.Y); } }
            public static Card Y2 { get { return new Card(50,Element.Y); } }
            public static Card Z1 { get { return new Card(51,Element.Z); } }
            public static Card Z2 { get { return new Card(52,Element.Z); } }
        }

    }
}
