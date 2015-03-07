using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace DeckEditor.Models
{
    public class AlchemyCardModel
    {
        public AlchemyCardModel()
        {
            Costs = new List<AlchemyCost>();
        }
        public int Id { get; set; }
        public int ElementId { get; set; }
        public string Name { get; set; }
        public int VictoryPoints { get; set; }
        public int RankId { get; set; }
        public List<AlchemyCost> Costs { get; set; }

        public AlchemyElement Element { get; set; }
        public AlchemyRank Rank { get; set; }

    }
}