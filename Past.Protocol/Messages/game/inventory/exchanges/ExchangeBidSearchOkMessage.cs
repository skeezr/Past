using Past.Protocol.IO;

namespace Past.Protocol.Messages
{
    public class ExchangeBidSearchOkMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 5802; }
        }
        public ExchangeBidSearchOkMessage()
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
