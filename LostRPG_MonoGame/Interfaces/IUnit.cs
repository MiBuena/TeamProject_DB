﻿namespace LostRPG_MonoGame.Interfaces
{
    public interface IUnit : IGameObject
    {
        int CurrentHP { get; set; }

        int MaxHP { get; }

        int AttackPoints { get; set; }

        int DefensePoints { get; set; }

        bool IsAlive { get; set; }
    }
}
