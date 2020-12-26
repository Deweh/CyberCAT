﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberCAT.Core.Classes.NodeRepresentations
{
    public class ItemData
    {
        public class NextItemEntry
        {
            public ulong ItemTdbId { get; set; }
            public uint ItemID { get; set; }
            public byte[] UnknownBytes2 { get; set; }
        }

        public class ModEntry
        {
            public ulong ItemTdbId { get; set; }
            public uint ItemID { get; set; }
            public byte[] UnknownBytes2 { get; set; }

            public override string ToString()
            {
                return NameResolver.GetName(ItemTdbId);
            }
        }

        public ulong ItemTdbId { get; set; }
        public uint ItemID { get; set; }
        public byte[] UnknownBytes2 { get; set; }
        public uint ItemQuantity { get; set; }
        public byte[] UnknownBytes3 { get; set; }
        public ModEntry[] ModEntries { get; set; }
        public byte[] ItemDataBytes { get; set; }

        /// <summary>
        /// Bytes that are not yet parsed into representation
        /// </summary>
        public byte[] TrailingBytes { get; set; }
        public override string ToString()
        {
            return NameResolver.GetName(ItemTdbId);
        }
    }
}