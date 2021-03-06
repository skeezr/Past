using Past.Protocol.IO;
using System;

namespace Past.Protocol.Messages
{
    public class CharacterSelectionMessage : NetworkMessage
	{
        public int id;
        public override uint Id
        {
        	get { return 152; }
        }
        public CharacterSelectionMessage()
        {
        }
        public CharacterSelectionMessage(int id)
        {
            this.id = id;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(id);
        }
        public override void Deserialize(IDataReader reader)
        {
            id = reader.ReadInt();
            if (id < 1 || id > 2147483647)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 1 || id > 2147483647");
		}
	}
}
