﻿using System.ComponentModel.DataAnnotations.Schema;
using LostRPG_MonoGame.Models.Graphics;
using LostRPG_MonoGame.Models.Structure.Regions;

namespace LostRPG_MonoGame.Models.Structure.Units.FriendlyUnits
{
    [Table("OldMage")]
    public class OldMage : FriendlyNPCUnit
    {
        private const int OldMageX = 704;
        private const int OldMageY = 288;
        private const int OldMageSizeX = 30;
        private const int OldMageSizeY = 33;
        private const SpriteType OldMageSprite = SpriteType.OldMageNPC;

        public OldMage() 
            : base(OldMageX, OldMageY, OldMageSizeX, OldMageSizeY, OldMageSprite)
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Region  { get; set; } 

        public bool QuestTaken { get; set; }

        public bool QuestCompleete { get; set; }

        //not sure about this nav property, do we need it?
        public virtual FriendlyNPCUnit FriendlyUnit { get; set; }
    }
}
