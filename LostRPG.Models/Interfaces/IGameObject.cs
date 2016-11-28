﻿namespace LostRPG.Models.Interfaces
{
    public interface IGameObject
    {
        int Id { get; set; }

        int X { get; set; }

        int Y { get; set; }

        int SizeX { get; }

        int SizeY { get; }
    }
}
