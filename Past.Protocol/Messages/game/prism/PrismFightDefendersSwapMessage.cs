using Past.Protocol.IO;
using System;

namespace Past.Protocol.Messages
{
    public class PrismFightDefendersSwapMessage : NetworkMessage
	{
        public double fightId;
        public int fighterId1;
        public int fighterId2;
        public override uint Id
        {
        	get { return 5902; }
        }
        public PrismFightDefendersSwapMessage()
        {
        }
        public PrismFightDefendersSwapMessage(double fightId, int fighterId1, int fighterId2)
        {
            this.fightId = fightId;
            this.fighterId1 = fighterId1;
            this.fighterId2 = fighterId2;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(fightId);
            writer.WriteInt(fighterId1);
            writer.WriteInt(fighterId2);
        }
        public override void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadDouble();
            fighterId1 = reader.ReadInt();
            if (fighterId1 < 0)
                throw new Exception("Forbidden value on fighterId1 = " + fighterId1 + ", it doesn't respect the following condition : fighterId1 < 0");
            fighterId2 = reader.ReadInt();
            if (fighterId2 < 0)
                throw new Exception("Forbidden value on fighterId2 = " + fighterId2 + ", it doesn't respect the following condition : fighterId2 < 0");
		}
	}
}
