using Past.Protocol.IO;

namespace Past.Protocol.Messages
{
    public class PartyLeaveRequestMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5593; }
        }
        public PartyLeaveRequestMessage()
        {
        }
        public override void Serialize(IDataWriter writer)
        {
        }
        public override void Deserialize(IDataReader reader)
        {
		}
	}
}
