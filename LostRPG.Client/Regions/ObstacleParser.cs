﻿namespace LostRPG.Client.Regions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LostRPG.Client.Interfaces;
    using LostRPG.Client.Resources.Static;
    using LostRPG.Models.Structure;
    using TiledSharp;

    public class ObstacleParser : IObstacleParser
    {
        private TmxMap currentMap;

        public IEnumerable<Obstacle> GetObstacles<T>() where T : Region<T>, new()
        {
            this.UpdateMap(typeof(T));
            return this.Parse();
        }

        private void UpdateMap(Type regionType)
        {
            if (regionType.IsEquivalentTo(typeof(StartRegion)))
            {
                this.currentMap = new TmxMap(TmxMapPaths.StartRegionMapFilePath);
            }
            else if (regionType.IsEquivalentTo(typeof(ValleyRegion)))
            {
                this.currentMap = new TmxMap(TmxMapPaths.ValleyRegionMapFilePath);
            }
            else if (regionType.IsEquivalentTo(typeof(MageLayerRegion)))
            {
                this.currentMap = new TmxMap(TmxMapPaths.MageLayerRegionMapFilePath);
            }
            else if (regionType.IsEquivalentTo(typeof(MageHouseRegion)))
            {
                this.currentMap = new TmxMap(TmxMapPaths.MageHouseRegionMapFilePath);
            }
        }

        private IEnumerable<Obstacle> Parse()
        {
            TmxList<TmxObject> tmxObjects = this.currentMap.ObjectGroups["Obstacles"].Objects;

            return tmxObjects
                .Select(to =>
                    new Obstacle((int)to.X, (int)to.Y, (int)to.Width, (int)to.Height));
        }
    }
}
