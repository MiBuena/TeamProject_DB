﻿namespace LostRPG_MonoGame.Interfaces
{
    using LostRPG_MonoGame.Structure;
    using LostRPG_MonoGame.Structure.Abilities;

    public interface IAbility
    {
        int VisualX { get; }

        int VisualY { get; }

        int VisualSizeX { get; }

        int VisualSizeY { get; }

        int Power { get; }

        IUnit Caster { get; }

        AbilityEffectEnum AbilityEffect { get; }
    }
}