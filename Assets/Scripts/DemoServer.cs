using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using UnityEngine;
using System;

namespace DemoGame
{
    public class DemoServer : NetworkBehaviour
    {
        
        public DemoPlayer player1;
        public DemoPlayer2 player2;
        public object Player1Prefab;
        public object Player2Prefab;

        public GameObject goServer;
        public void Start()
        {
            Player1Prefab = Resources.Load("Prefabs/Player1");
            Player2Prefab = Resources.Load("Prefabs/Player2");
        }
        public override void NetworkStart()
        {   
            if (NetworkManager.Singleton.IsServer) {
                Debug.Log("Server started.");
            }
            else{
                Debug.Log("Using spawner to send rpc");
                SpawnPlayerServerRpc(NetworkManager.Singleton.LocalClientId);
            }

        }

        [ServerRpc(RequireOwnership = false)]
        public void SpawnPlayerServerRpc(ulong ClientId)
        {   
            if (IsServer){
                SpawnPlayer(ClientId);
            }
        }

        public GameObject goPlayer;
        public void SpawnPlayer(ulong ClientId)
        {   
            if (NetworkManager.Singleton.ConnectedClientsList.Count == 1){
                goPlayer = Instantiate(Player1Prefab as GameObject);
                goPlayer.GetComponent<NetworkObject>().SpawnAsPlayerObject(ClientId);
                Debug.Log("Spawned Player 1, owner clientId = " + ClientId);
            }
            else{
                goPlayer = Instantiate(Player2Prefab as GameObject);
                goPlayer.GetComponent<NetworkObject>().SpawnAsPlayerObject(ClientId);
                Debug.Log("Spawned Player 2, owner clientId = " + ClientId);
            }
            
        }


        [ClientRpc]
        public void NudgeClientRpc(Vector3 dir, int player_num){
            if (player_num == 1){
                if (NetworkManager.Singleton.ConnectedClients.TryGetValue(2,
                    out var networkedClient2))
                {
                    player1 = networkedClient2.PlayerObject.GetComponent<DemoPlayer>();
                    if (player1){
                        player1.p1_rb.AddForce(dir);
                    }
                }
                Debug.Log($"ClientRpc called, nudged player1 in direction {dir}");
            }
            else if (player_num == 2){
                if (NetworkManager.Singleton.ConnectedClients.TryGetValue(3,
                    out var networkedClient3))
                {
                    player2 = networkedClient3.PlayerObject.GetComponent<DemoPlayer2>();
                    if (player2){
                        player2.p2_rb.AddForce(dir);
                    }
                }
                Debug.Log($"ClientRpc called, nudged player2 in direction {dir}");
            }

        }

    }
}
