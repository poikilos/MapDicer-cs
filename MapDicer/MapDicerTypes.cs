﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapDicer
{
    /// <summary>
    /// This is a unique spatial position where y is an abstract computation from the Lod and
    /// layer.
    /// </summary>
    struct MapDicerPos
    {
        public short LodId;
        public short Layer;
        public short X;
        public short Z;
        public short Y
        {
            get
            {
                return (short)(LodId * SettingModel.MaxLayerCount + Layer);
            }
            set
            {
                LodId = (short)(value / SettingModel.MaxLayerCount);
                Layer = (short)(value % SettingModel.MaxLayerCount);
            }
        }
        /// <summary>
        /// Convert a mapblock offset (1 per mapblock) to a unique Mapblock Id given the
        /// current level of detail and layer (z is computed from lod and layer, so this part
        /// differs from Minetest. For compatibility with Minetest position hashes, the unusual
        /// type casting must remain (This must match mtcompat/Database.getBlockAsInteger).
        /// See
        /// https://git.minetest.org/minetest/minetest/src/branch/master/src/database.cpp
        /// </summary>
        /// <param name="pos">A block offset in [x, z] format where y is zenith and 1 is the
        /// size of a Mapblock in this Lod</param>
        /// <param name="layer">A key for a layer entity such as that of "terrain" or
        /// "elevation"</param>
        /// <returns>a primary key for the Mapblock at the given location</returns>
        public long getBlockLayerAsInteger()
        {
            if (Layer >= SettingModel.MaxLayerCount)
            {
                throw new ApplicationException("The layer number cannot be >= MaxLayerCount");
            }
            return (long)((ulong)Z * 0x1000000 +
                (ulong)Y * 0x1000 +
                (ulong)Z);
        }
    }
}
