using System;

namespace GameFlow.Common
{
    public static class CardAbilities
    {
        public static CardAbility NoOp = (pl1, pl2, pool) => { };
        public static CardAbility DrawACard = (p1, p2, pool) =>
                                              {
                                                  Console.Write("Activating Draw-A-Card");
                                                  p1.Hand.DrawFrom(p1.DrawPile);
                                              };
        public static CardAbility DrawTwoCards = (CardAbility)Delegate.Combine(DrawACard, DrawACard);

        public static CardAbility FreeCardFromPool = (p1, p2, pool) =>
                                                     {
                                                         p1.DiscardPile.Add();
                                                     };
    }

    public delegate void CardAbility(Player thisPlayer, Player thatPlayer, ICardPool pool);
}