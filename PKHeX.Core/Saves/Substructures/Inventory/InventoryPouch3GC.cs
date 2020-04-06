using System;

namespace PKHeX.Core
{
    public sealed class InventoryPouch3GC : InventoryPouch
    {
        public InventoryPouch3GC(InventoryType type, ushort[] legal, int maxcount, int offset, int size)
            : base(type, legal, maxcount, offset, size)
        {
        }

        public override void GetPouch(byte[] Data)
        {
            var items = new InventoryItem[PouchDataSize];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new InventoryItem
                {
                    Index = BigEndian.ToUInt16(Data, Offset + (i * 4)),
                    Count = BigEndian.ToUInt16(Data, Offset + (i * 4) + 2)
                };
            }
            Items = items;
        }

        public override void SetPouch(byte[] Data)
        {
            if (Items.Length != PouchDataSize)
                throw new ArgumentException("Item array length does not match original pouch size.");

            for (int i = 0; i < Items.Length; i++)
            {
                BigEndian.GetBytes((ushort)Items[i].Index).CopyTo(Data, Offset + (i * 4));
                BigEndian.GetBytes((ushort)Items[i].Count).CopyTo(Data, Offset + (i * 4) + 2);
            }
        }
    }
}