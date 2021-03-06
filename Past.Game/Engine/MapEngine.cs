﻿using Past.Common.Data;
using Past.Game.Network;
using Past.Protocol;
using Past.Protocol.Messages;
using System.Collections.Generic;
using Past.Protocol.Types;

namespace Past.Game.Engine
{
    public class MapEngine
    {
        public readonly List<GameClient> Clients;

        public MapEngine()
        {
            Clients = new List<GameClient>();
        }

        public void Send(NetworkMessage message)
        {
            Clients.ForEach(client => client.Send(message));
        }

        public void SendGameRolePlayShowActorMessage(GameClient client)
        {
            foreach (GameClient mapClient in Clients)
            {
                client.Send(new GameRolePlayShowActorMessage(mapClient.Character.GetGameRolePlayCharacterInformations));
            }
        }

        public void SendCharacterLevelUpInformation(GameClient client)
        {
            foreach (GameClient mapClient in Clients)
            {
                if (mapClient != client)
                {
                    Send(new CharacterLevelUpInformationMessage(client.Character.Level, client.Character.Name, client.Character.Id, 0));
                }
            }
        }

        public void AddClient(GameClient client)
        {
            lock (Clients)
            {
                if (!Clients.Contains(client))
                {
                    Clients.Add(client);
                    SendGameRolePlayShowActorMessage(client);
                    Send(new GameRolePlayShowActorMessage(client.Character.GetGameRolePlayCharacterInformations));
                }
            }
        }

        public void RemoveClient(GameClient client)
        {
            lock (Clients)
            {
                if (Clients.Contains(client))
                {
                    Clients.Remove(client);
                    Send(new GameContextRemoveElementMessage(client.Character.Id));
                }
            }
        }

        public static void Initialize()
        {
            foreach (Map map in Map.Maps)
            {
                map.Instance = new MapEngine();
            }
        }

        public InteractiveElement[] GetInteractiveElements(int mapId)
        {
            return Interactive.Interactives.ContainsKey(mapId) ? Interactive.Interactives[mapId] : new InteractiveElement[0];
        }
    }
}
