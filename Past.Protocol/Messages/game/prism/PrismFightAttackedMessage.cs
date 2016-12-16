using Past.Protocol.IO;
using System;

namespace Past.Protocol.Messages
{
    public class PrismFightAttackedMessage : NetworkMessage
	{
        public short worldX;
        public short worldY;
        public int mapId;
        public short subareaId;
        public override uint Id
        {
        	get { return 5894; }
        }
        public PrismFightAttackedMessage()
        {
        }
        public PrismFightAttackedMessage(short worldX, short worldY, int mapId, short subareaId)
        {
            this.worldX = worldX;
            this.worldY = worldY;
            this.mapId = mapId;
            this.subareaId = subareaId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteInt(mapId);
            writer.WriteShort(subareaId);
        }
        public override void Deserialize(IDataReader reader)
        {
            worldX = reader.ReadShort();
            if (worldX < -255 || worldX > 255)
                throw new Exception("Forbidden value on worldX = " + worldX + ", it doesn't respect the following condition : worldX < -255 || worldX > 255");
            worldY = reader.ReadShort();
            if (worldY < -255 || worldY > 255)
                throw new Exception("Forbidden value on worldY = " + worldY + ", it doesn't respect the following condition : worldY < -255 || worldY > 255");
            mapId = reader.ReadInt();
            if (mapId < 0)
                throw new Exception("Forbidden value on mapId = " + mapId + ", it doesn't respect the following condition : mapId < 0");
            subareaId = reader.ReadShort();
            if (subareaId < 0)
                throw new Exception("Forbidden value on subareaId = " + subareaId + ", it doesn't respect the following condition : subareaId < 0");
		}
	}
}
