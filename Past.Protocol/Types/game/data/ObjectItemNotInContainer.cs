using Past.Protocol.IO;
using System;

namespace Past.Protocol.Types
{
    public class ObjectItemNotInContainer : Item
    {
        public short objectGID;
        public ObjectEffect[] effects;
        public int objectUID;
        public int quantity;
        public new const short Id = 134;
        public override short TypeId
        {
            get { return Id; }
        }
        public ObjectItemNotInContainer()
        {
        }
        public ObjectItemNotInContainer(short objectGID, ObjectEffect[] effects, int objectUID, int quantity)
        {
            this.objectGID = objectGID;
            this.effects = effects;
            this.objectUID = objectUID;
            this.quantity = quantity;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(objectGID);
            writer.WriteUShort((ushort)effects.Length);
            foreach (var entry in effects)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
            writer.WriteInt(objectUID);
            writer.WriteInt(quantity);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            objectGID = reader.ReadShort();
            if (objectGID < 0)
                throw new Exception("Forbidden value on objectGID = " + objectGID + ", it doesn't respect the following condition : objectGID < 0");
            var limit = reader.ReadUShort();
            effects = new ObjectEffect[limit];
            for (int i = 0; i < limit; i++)
            {
                effects[i] = (ObjectEffect)ProtocolTypeManager.GetInstance(reader.ReadUShort());
                effects[i].Deserialize(reader);
            }
            objectUID = reader.ReadInt();
            if (objectUID < 0)
                throw new Exception("Forbidden value on objectUID = " + objectUID + ", it doesn't respect the following condition : objectUID < 0");
            quantity = reader.ReadInt();
            if (quantity < 0)
                throw new Exception("Forbidden value on quantity = " + quantity + ", it doesn't respect the following condition : quantity < 0");
        }
    }
}
          
	