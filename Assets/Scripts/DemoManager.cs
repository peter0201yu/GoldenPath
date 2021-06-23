using MLAPI;
using UnityEngine;

namespace DemoGame
{
    public class DemoManager : MonoBehaviour
    {   
        void OnGUI()
        {
            GUILayout.BeginArea(new Rect(10, 10, 300, 300));
            if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
            {
                StartButtons();
            }
            else
            {   
                StatusLabels();

                // MovePlayers();
            }

            GUILayout.EndArea();
        }

        void Update()
        {
            
        }

        public void StartButtons()
        {
            if (GUILayout.Button("Host")) NetworkManager.Singleton.StartHost();
            if (GUILayout.Button("Server")) NetworkManager.Singleton.StartServer();
            if (GUILayout.Button("Client")) NetworkManager.Singleton.StartClient();
        }

        static void StatusLabels()
        {
            var mode = NetworkManager.Singleton.IsHost ?
                "Host" : NetworkManager.Singleton.IsServer ? "Server" : "Client";

            GUILayout.Label("Transport: " +
                NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name);
            GUILayout.Label("Mode: " + mode);
            GUILayout.Label("ClientId: " + NetworkManager.Singleton.LocalClientId);
            // if (mode == "Server"){
                GUILayout.Label("ServerClientId: " + NetworkManager.Singleton.ServerClientId);
                GUILayout.Label("Connect clients: " + NetworkManager.Singleton.ConnectedClientsList.Count);
            // }
        }

        // static void MovePlayers()
        // {   
        //     if (NetworkManager.Singleton.ConnectedClients.TryGetValue(0, out var networkServer)){
        //         var server = networkServer.PlayerObject.GetComponent<DemoServer>();
        //         server.Move();
        //     }
        // }

        // static void MoveP2()
        // {
            // if (GUILayout.Button("Move")){
            //     if (NetworkManager.Singleton.ConnectedClients.TryGetValue(NetworkManager.Singleton.LocalClientId,
            //         out var networkedClient))
            //     {
            //         var player = networkedClient.PlayerObject.GetComponent<DemoPlayer2>();
            //         player.Move();
            //     }
            // }
        //     if (NetworkManager.Singleton.ConnectedClients.TryGetValue(NetworkManager.Singleton.LocalClientId,
        //             out var networkedClient))
        //         {   
        //             var player2 = networkedClient.PlayerObject.GetComponent<DemoPlayer2>();
        //             if (player2){
        //                 player2.Move();
        //             }
        //         }
        // }
    }
}