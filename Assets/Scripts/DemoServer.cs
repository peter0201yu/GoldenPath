using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using UnityEngine;
using System;

namespace DemoGame
{
    public class DemoServer : NetworkBehaviour
    {
        public NetworkVariableVector3 p1_Position = new NetworkVariableVector3(new NetworkVariableSettings
        {
            WritePermission = NetworkVariablePermission.ServerOnly,
            ReadPermission = NetworkVariablePermission.Everyone
        });

        public NetworkVariableVector3 p2_Position = new NetworkVariableVector3(new NetworkVariableSettings
        {
            WritePermission = NetworkVariablePermission.ServerOnly,
            ReadPermission = NetworkVariablePermission.Everyone
        });

        public GameObject goSpawner;
        public SpawnerTest spawner;
        public DemoPlayer player1;
        public DemoPlayer2 player2;

        public override void NetworkStart(){
            if (IsServer){
                p1_Position.Value = new Vector3(4f, 0.5f, -4f);
                p2_Position.Value = new Vector3(-4f, 0.5f, 4f);
            }
        }

        // public void MovePlayers(){

        //     if (NetworkManager.Singleton.ConnectedClients.TryGetValue(2,
        //         out var networkedClient2))
        //     {
        //         player1 = networkedClient2.PlayerObject.GetComponent<DemoPlayer>();
        //         if (player1){
        //             p1_Position.Value += (Vector3.Normalize(player1.p1_move_vector.Value) / 10);
        //         }
        //         else{
        //             Debug.Log("No player 1! Error.");
        //         }
        //     }

        //     if (NetworkManager.Singleton.ConnectedClients.TryGetValue(3,
        //         out var networkedClient3))
        //     {
        //         player2 = networkedClient3.PlayerObject.GetComponent<DemoPlayer2>();
        //         if (player2){
        //             p2_Position.Value += (Vector3.Normalize(player2.p2_move_vector.Value) / 10);
        //         }
        //         else{
        //             Debug.Log("No player 2! Error.");
        //         }
        //     }

        // }

        public void Update(){
            // if (IsServer){
            //     MovePlayers();
            // }
        }
        

    }
}
