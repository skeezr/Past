using Past.Protocol.IO;

namespace Past.Protocol.Messages
{
    public class PauseDialogMessage : NetworkMessage
	{
        public override uint Id
        {
        	get { return 6012; }
        }
        public PauseDialogMessage()
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
