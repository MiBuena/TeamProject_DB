﻿namespace LostRPG.Models.Structure.BoostItems
{
    using LostRPG.Models.Graphics;

    public class Shield : Item
    {
        private const int ShieldDefaultDamageBoost = 0;
        private const int ShieldDefaultHealthBoost = 0;
        private const int ShieldDefaultDefenceBoost = 50;
        private const int ShieldDefaultSizeX = 32;
        private const int ShieldDefaultSizeY = 32;

        private const SpriteType ShieldDefaultSprite = SpriteType.Shield;

        public Shield(int x, int y) 
            : base(x, y, ShieldDefaultSizeX, ShieldDefaultSizeY, ShieldDefaultHealthBoost, 
                  ShieldDefaultDamageBoost, ShieldDefaultDefenceBoost, ShieldDefaultSprite)
        {
        }

        protected Shield()
        {
        }
    }
}
