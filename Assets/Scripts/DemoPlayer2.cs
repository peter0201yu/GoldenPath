using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using UnityEngine;

namespace DemoGame
{
    public class DemoPlayer2 : NetworkBehaviour
    {
        public DemoServer server;
        public GameObject goServer;
        public GameObject player2;
        public Rigidbody p2_rb;
        
        void Awake(){
            Debug.Log("DemoPlayer2 Awake");
            goServer = GameObject.FindGameObjectsWithTag("goServer")[0];
            server = goServer.GetComponent<DemoServer>();
            transform.position = new Vector3(-4f, 0.5f, 4f);
            Debug.Log("transform.position" + transform.position);

            player2 = GameObject.FindGameObjectsWithTag("player2")[0];
            p2_rb = player2.GetComponent<Rigidbody>();
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
                MoveP2ServerRpc(up);
            }
            if (Input.GetKey(KeyCode.DownArrow)){
                MoveP2ServerRpc(down);
            }
            if (Input.GetKey(KeyCode.RightArrow)){
                MoveP2ServerRpc(right);
            }
            if (Input.GetKey(KeyCode.LeftArrow)){
                MoveP2ServerRpc(left);
            }
        }

        [ServerRpc]
        void MoveP2ServerRpc(Vector3 dir){
            Debug.Log($"MoveP2 ServerRpc called, nudged in direction {dir}.");
            server.NudgeClientRpc(dir, 2);
        }


        void Update()
        {   
            if (NetworkManager.Singleton.LocalClientId == 3){
                Move();
            }
        }
    }
}
