﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CardDesignEntities : DbContext
    {
        public CardDesignEntities()
            : base("name=CardDesignEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AlchemyCard> AlchemyCards { get; set; }
        public virtual DbSet<AlchemyCost> AlchemyCosts { get; set; }
        public virtual DbSet<AlchemyElement> AlchemyElements { get; set; }
        public virtual DbSet<AlchemyRank> AlchemyRanks { get; set; }
        public virtual DbSet<Deck> Decks { get; set; }
        public virtual DbSet<AlchemyGoal> AlchemyGoals { get; set; }
    
        public virtual int MoveCostDown(Nullable<int> costId)
        {
            var costIdParameter = costId.HasValue ?
                new ObjectParameter("costId", costId) :
                new ObjectParameter("costId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MoveCostDown", costIdParameter);
        }
    
        public virtual int MoveCostUp(Nullable<int> costId)
        {
            var costIdParameter = costId.HasValue ?
                new ObjectParameter("costId", costId) :
                new ObjectParameter("costId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MoveCostUp", costIdParameter);
        }
    }
}
