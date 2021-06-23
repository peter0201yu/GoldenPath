using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using UnityEngine;

namespace DemoGame
{
    public class DemoPlayer : NetworkBehaviour
    {
        public DemoServer server;
        public GameObject goServer;
        public GameObject player1;
        public Rigidbody p1_rb;
        
        void Awake(){
            Debug.Log("DemoPlayer Awake");
            goServer = GameObject.FindGameObjectsWithTag("goServer")[0];
            server = goServer.GetComponent<DemoServer>();
            transform.position = new Vector3(4f, 0.5f, -4f);
            Debug.Log("transform.position" + transform.position);

            player1 = GameObject.FindGameObjectsWithTag("player1")[0];
            p1_rb = player1.GetComponent<Rigidbody>();
        }

        public override void NetworkStart(){
            
            Debug.Log("Local clientId: "+ NetworkManager.Singleton.LocalClientId);
            Debug.Log("Connected List: "+ NetworkManager.Singleton.ConnectedClientsList);
        }

        Vector3 left = new Vector3(-1, 0, 0);
        Vector3 right = new Vector3(1, 0, 0);
        Vector3 up = new Vector3(0, 0, 1);
        Vector3 down = new Vector3(0, 0, -1);
        public void Move(){
            if (Input.GetKey(KeyCode.UpArrow)){
                MoveP1ServerRpc(up);
            }
            if (Input.GetKey(KeyCode.DownArrow)){
                MoveP1ServerRpc(down);
            }
            if (Input.GetKey(KeyCode.RightArrow)){
                MoveP1ServerRpc(right);
            }
            if (Input.GetKey(KeyCode.LeftArrow)){
                MoveP1ServerRpc(left);
            }
        }

        [ServerRpc]
        void MoveP1ServerRpc(Vector3 dir){
            Debug.Log($"MoveP1 ServerRpc called, nudged in direction {dir}.");
            server.NudgeP1ClientRpc(dir);
        }

        void Update()
        {   
            if (NetworkManager.Singleton.LocalClientId == 2){
                Move();
            }
        }
    }
}
