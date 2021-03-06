﻿namespace LostRPG.Client.Regions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using LostRPG.Client.GameEngine;
    using LostRPG.Client.Interfaces;
    using LostRPG.Models.Graphics;
    using LostRPG.Models.Interfaces;
    using LostRPG.Models.Structure;
    using LostRPG.Models.Structure.BoostItems;
    using LostRPG.Models.Structure.Units.EnemyUnits;
    using LostRPG.Models.Structure.Units.FriendlyUnits;

    [NotMapped]
    public abstract class Region<T> : GameObject, IRegionInterface
        where T : Region<T>, new()
    {
        private const int DefaultX = 0;
        private const int DefaultY = 0;
        private const int DefaultSizeX = 1280;
        private const int DefaultSizeY = 720;

        private static readonly T Instance = new T();
        ////
        private bool isInitialised;

        private RegionEntities regionEntities;

        protected Region() : base(DefaultX, DefaultY, DefaultSizeX, DefaultSizeY)
        {
            this.RegionFriendlyNPCs = new List<FriendlyNPCUnit>();
            this.RegionEnemies = new List<EnemyNPCUnit>();
            this.RegionObstacles = new List<Obstacle>();
            this.RegionGateways = new List<Gateway>();
            this.RegionItems = new List<Item>();

            this.ObstacleParser = new ObstacleParser();
            this.isInitialised = false;
        }

        protected IObstacleParser ObstacleParser { get; }
        
        public static T GetInstance
        {
            get
            {
                if (Instance.isInitialised)
                {
                    return Instance;
                }

                Instance.Initialise();
                Instance.isInitialised = true;
                return Instance;
            }
        }

        public SpriteType SpriteType { get; protected set; }

        public List<FriendlyNPCUnit> RegionFriendlyNPCs { get; private set; }

        public List<EnemyNPCUnit> RegionEnemies { get; private set; }

        public List<Obstacle> RegionObstacles { get; }

        public List<Gateway> RegionGateways { get; }

        public List<Item> RegionItems { get; private set; }

        public bool ReloadRegion(IRegionState regionState)
        {
            //regionState.
            this.RegionFriendlyNPCs = regionState.FriendlyNPCs.ToList();
            this.RegionEnemies = regionState.Enemies.ToList();
            this.RegionItems = regionState.Items.ToList();

            return true;
        }

        protected RegionEntities RegionEntities
        {
            get
            {
                return this.regionEntities;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.regionEntities = value;
            }
        }

        protected abstract void SetFriendlyNPCs();

        protected abstract void SetEnemies();

        protected abstract void SetGateways();

        protected abstract void SetObstacles();

        protected abstract void SetBoostItems();

        protected void Initialise()
        {
            this.RegionEntities = RegionEntities.GetInstance();
            this.SetFriendlyNPCs();
            this.SetEnemies();
            this.SetGateways();
            this.SetObstacles();
            this.SetBoostItems();
        }
    }
}
