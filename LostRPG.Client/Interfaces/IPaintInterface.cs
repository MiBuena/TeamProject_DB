﻿namespace LostRPG.Client.Interfaces
{
    using LostRPG.Models.Interfaces;

    public interface IPaintInterface
    {
        void AddObject(IRenderable renderableObject);

        void RemoveObject(IRenderable renderableObject);

        void RedrawObject(IRenderable renderableObject);

        void SetBackground(IRenderable renderableObject);

        void RedrawObjectWithAShield(IRenderable renderableObject);
    }
}
