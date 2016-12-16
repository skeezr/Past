using Past.Protocol.IO;
using System;

namespace Past.Protocol.Messages
{
    public class GameActionFightSlideMessage : AbstractGameActionMessage
	{
        public int targetId;
        public short startCellId;
        public short endCellId;
        public override uint Id
        {
        	get { return 5525; }
        }
        public GameActionFightSlideMessage()
        {
        }
        public GameActionFightSlideMessage(short actionId, int sourceId, int targetId, short startCellId, short endCellId) : base(actionId, sourceId)
        {
            this.targetId = targetId;
            this.startCellId = startCellId;
            this.endCellId = endCellId;
        }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(targetId);
            writer.WriteShort(startCellId);
            writer.WriteShort(endCellId);
        }
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadInt();
            startCellId = reader.ReadShort();
            if (startCellId < -1 || startCellId > 559)
                throw new Exception("Forbidden value on startCellId = " + startCellId + ", it doesn't respect the following condition : startCellId < -1 || startCellId > 559");
            endCellId = reader.ReadShort();
            if (endCellId < -1 || endCellId > 559)
                throw new Exception("Forbidden value on endCellId = " + endCellId + ", it doesn't respect the following condition : endCellId < -1 || endCellId > 559");
		}
	}
}
