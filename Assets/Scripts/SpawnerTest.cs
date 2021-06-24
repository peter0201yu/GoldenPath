using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using UnityEngine;

namespace DemoGame
{
    public class SpawnerTest : NetworkBehaviour
    {   
        // public GameObject Server;
        // object Player1;
        // object Player2;

        // public GameObject goServer;
        // public void Start()
        // {
        //     // Server =  Resources.Load("Prefabs/server");
        //     Player1 = Resources.Load("Prefabs/Player1");
        //     Player2 = Resources.Load("Prefabs/Player2");
        // }
        // public override void NetworkStart()
        // {   
        //     if (NetworkManager.Singleton.IsServer) {
        //         Debug.Log("Server started.");
        //     }
        //     else{
        //         Debug.Log("Using spawner to send rpc");
        //         SpawnPlayerServerRpc(NetworkManager.Singleton.LocalClientId);
        //     }

        // }

        // [ServerRpc(RequireOwnership = false)]
        // public void SpawnPlayerServerRpc(ulong ClientId, ServerRpcParams rpcParams = default)
        // {   
        //     if (IsServer){
        //         SpawnPlayer(ClientId);
        //     }
        // }

        // public GameObject goPlayer;
        // public void SpawnPlayer(ulong ClientId)
        // {   
        //     if (NetworkManager.Singleton.ConnectedClientsList.Count == 1){
        //         goPlayer = Instantiate(Player1 as GameObject);
        //         goPlayer.GetComponent<NetworkObject>().SpawnAsPlayerObject(ClientId);
        //         Debug.Log("Spawned Player 1, owner clientId = " + ClientId);
        //     }
        //     else{
        //         goPlayer = Instantiate(Player2 as GameObject);
        //         goPlayer.GetComponent<NetworkObject>().SpawnAsPlayerObject(ClientId);
        //         Debug.Log("Spawned Player 2, owner clientId = " + ClientId);
        //     }
            
        // }
        void Update()
        {

        }
    }
}