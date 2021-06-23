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

        // public NetworkVariableVector3 p2_move_vector = new NetworkVariableVector3(new NetworkVariableSettings
        // {
        //     WritePermission = NetworkVariablePermission.Everyone,
        //     ReadPermission = NetworkVariablePermission.Everyone
        // });
        
        void Awake(){
            Debug.Log("DemoPlayer Awake");
            goServer = GameObject.FindGameObjectsWithTag("goServer")[0];
            server = goServer.GetComponent<DemoServer>();
            transform.position = server.p2_Position.Value;
            Debug.Log("transform.position" + transform.position);

            server.p2_Position.OnValueChanged += OnChangeP2Position;
        }

        public override void NetworkStart(){
            
            Debug.Log("Local clientId: "+ NetworkManager.Singleton.LocalClientId);
            Debug.Log("Connected List: "+ NetworkManager.Singleton.ConnectedClientsList);
            // p2_move_vector.Value = Vector3.zero;
        }

        void OnChangeP2Position(Vector3 OldP2Position, Vector3 NewP2Position){
            transform.position = server.p2_Position.Value;
            // p2_move_vector.Value = Vector3.zero;
            Debug.Log($"New p2_position is {NewP2Position}. Before it was {OldP2Position}");
            // Debug.Log($"p2_move_vector reset to {p2_move_vector.Value}");
        }

        Vector3 left = new Vector3(-1, 0, 0);
        Vector3 right = new Vector3(1, 0, 0);
        Vector3 up = new Vector3(0, 0, 1);
        Vector3 down = new Vector3(0, 0, -1);
        public void Move(){
            if (Input.GetKey(KeyCode.UpArrow)){
                MoveP2ServerRpc(up);
                // p2_move_vector.Value += up;
            }
            if (Input.GetKey(KeyCode.DownArrow)){
                MoveP2ServerRpc(down);
                // p2_move_vector.Value += down;
            }
            if (Input.GetKey(KeyCode.RightArrow)){
                MoveP2ServerRpc(right);
                // p2_move_vector.Value += right;
            }
            if (Input.GetKey(KeyCode.LeftArrow)){
                MoveP2ServerRpc(left);
                // p2_move_vector.Value += left;
            }
        }

        [ServerRpc]
        void MoveP2ServerRpc(Vector3 dir){
            Debug.Log("MoveP1 ServerRpc called");
            server.p2_Position.Value += (Vector3.Normalize(dir) / 10);
        }

        void Update()
        {   
            if (NetworkManager.Singleton.LocalClientId == 3){
                Move();
            }
        }
    }
}
