using Past.Protocol.IO;
using System;

namespace Past.Protocol.Messages
{
    public class TaxCollectorAttackedMessage : NetworkMessage
	{
        public short firstNameId;
        public short lastNameId;
        public short worldX;
        public short worldY;
        public int mapId;
        public override uint Id
        {
        	get { return 5918; }
        }
        public TaxCollectorAttackedMessage()
        {
        }
        public TaxCollectorAttackedMessage(short firstNameId, short lastNameId, short worldX, short worldY, int mapId)
        {
            this.firstNameId = firstNameId;
            this.lastNameId = lastNameId;
            this.worldX = worldX;
            this.worldY = worldY;
            this.mapId = mapId;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(firstNameId);
            writer.WriteShort(lastNameId);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteInt(mapId);
        }
        public override void Deserialize(IDataReader reader)
        {
            firstNameId = reader.ReadShort();
            if (firstNameId < 0)
                throw new Exception("Forbidden value on firstNameId = " + firstNameId + ", it doesn't respect the following condition : firstNameId < 0");
            lastNameId = reader.ReadShort();
            if (lastNameId < 0)
                throw new Exception("Forbidden value on lastNameId = " + lastNameId + ", it doesn't respect the following condition : lastNameId < 0");
            worldX = reader.ReadShort();
            if (worldX < -255 || worldX > 255)
                throw new Exception("Forbidden value on worldX = " + worldX + ", it doesn't respect the following condition : worldX < -255 || worldX > 255");
            worldY = reader.ReadShort();
            if (worldY < -255 || worldY > 255)
                throw new Exception("Forbidden value on worldY = " + worldY + ", it doesn't respect the following condition : worldY < -255 || worldY > 255");
            mapId = reader.ReadInt();
            if (mapId < 0)
                throw new Exception("Forbidden value on mapId = " + mapId + ", it doesn't respect the following condition : mapId < 0");
		}
	}
}
