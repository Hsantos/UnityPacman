﻿using System.Collections.Generic;
using PacEngine.board.prizes;
using PacEngine.utils;

namespace PacEngine.board.tiles
{
    public class TileInfo
    {
        public TileFactory.TileTypes TileType { get; set; }
        public PrizeFactory.PrizeTypes PrizeType { get; set; }
        public List<Vector> ForbiddenMovement { get; set; }
    }

    public class TileFactory
    {
        public enum TileTypes
        {
            WALKABLE,
            BLOCKER
        }

        internal static AbstractBoardTile GetTile(TileInfo info, Vector position)
        {
            switch(info.TileType)
            {
                case TileTypes.WALKABLE:
                    return new WalkableBoardTile(position, PrizeFactory.GetPrize(info.PrizeType, position), info.ForbiddenMovement);
                case TileTypes.BLOCKER:
                    return new BlockerBoardTile(position);
            }

            throw new PacException($"Tile of type {info.TileType} is not implemented in TileFactory.GetTile");
        }
    }
}
