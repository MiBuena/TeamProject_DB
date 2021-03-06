﻿namespace LostRPG.Models.Structure.BoostItems
{
    using System.ComponentModel.DataAnnotations.Schema;
    using LostRPG.Models.GameState;
    using LostRPG.Models.Graphics;
    using LostRPG.Models.Interfaces;

    public abstract class Item : GameObject, IRenderable
    {
        protected Item()
        {
        }

        protected Item(int x, int y, int sizeX, int sizeY, int healthBoost, 
            int damageBoost, int defenseBoost, SpriteType spriteType) 
            : base(x, y, sizeX, sizeY)
        {
            this.SpriteType = spriteType;
            this.HealthPointsBoost = healthBoost;
            this.DamagePointsBoost = damageBoost;
            this.DefensePointsBoost = defenseBoost;
            this.HasBeenUsed = false;
        }

        public int HealthPointsBoost { get; }

        public int DamagePointsBoost { get; }

        public int DefensePointsBoost { get; }

        [NotMapped]
        public SpriteType SpriteType { get; }

        public bool HasBeenUsed { get; set; }

        public virtual RegionState RegionState { get; set; }

        public void ApplyItemEffects(IUnit unit)
        {
            unit.AttackPoints += this.DamagePointsBoost;
            unit.CurrentHP += this.HealthPointsBoost;
            unit.DefensePoints += this.DefensePointsBoost;
        }
    }
}
