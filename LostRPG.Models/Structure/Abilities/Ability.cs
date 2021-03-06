﻿namespace LostRPG.Models.Structure.Abilities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using LostRPG.Models.Interfaces;

    [NotMapped]
    public abstract class Ability : GameObject, IAbility, ITimeoutable
    {
        ////private int maxLifespanInMS;

        private int currentLifespanInMS;

        protected Ability(int x, int y, int sizeX, int sizeY, int visualX, int visualY, 
            int visualSizeX, int visualSizeY, int power, AbilityEffectEnum abilityEffect, IUnit caster)
            : base(x, y, sizeX, sizeY)
        {
            this.VisualX = visualX;
            this.VisualY = visualY;
            this.VisualSizeX = visualSizeX;
            this.VisualSizeY = visualSizeY;
            this.Power = power;
            this.AbilityEffect = abilityEffect;
            this.Caster = caster;
        }

        public int VisualX { get; set; }

        public int VisualY { get; set; }

        public int VisualSizeX { get; set; }

        public int VisualSizeY { get; set; }

        public int Power { get; set; }

        public AbilityEffectEnum AbilityEffect { get; set; }

        public IUnit Caster { get; set; }
        
        public int MaxLifespanInMS { get; protected set; }
        
        public int CurrentLifespanInMS
        {
            get
            {
                return this.currentLifespanInMS;
            }

            set
            {
                if (value > this.MaxLifespanInMS)
                {
                    this.HasTimedOut = true;
                }
                else
                {
                    this.currentLifespanInMS = value;
                }
            }
        }

        public bool HasTimedOut { get; set; }
    }
}
