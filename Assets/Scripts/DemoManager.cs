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
            if (mode == "Server"){
                GUILayout.Label("ServerClientId: " + NetworkManager.Singleton.ServerClientId);
                GUILayout.Label("Connect clients: " + NetworkManager.Singleton.ConnectedClientsList.Count);
            }
        }

    }
}