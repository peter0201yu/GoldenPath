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

        // public NetworkVariableVector3 p1_move_vector = new NetworkVariableVector3(new NetworkVariableSettings
        // {
        //     WritePermission = NetworkVariablePermission.Everyone,
        //     ReadPermission = NetworkVariablePermission.Everyone
        // });
        
        void Awake(){
            Debug.Log("DemoPlayer Awake");
            goServer = GameObject.FindGameObjectsWithTag("goServer")[0];
            server = goServer.GetComponent<DemoServer>();
            transform.position = server.p1_Position.Value;
            Debug.Log("transform.position" + transform.position);

            server.p1_Position.OnValueChanged += OnChangeP1Position;
        }

        public override void NetworkStart(){
            
            Debug.Log("Local clientId: "+ NetworkManager.Singleton.LocalClientId);
            Debug.Log("Connected List: "+ NetworkManager.Singleton.ConnectedClientsList);
            // p1_move_vector.Value = Vector3.zero;
        }

        void OnChangeP1Position(Vector3 OldP1Position, Vector3 NewP1Position){
            transform.position = server.p1_Position.Value;
            // p1_move_vector.Value = Vector3.zero;
            Debug.Log($"New p1_position is {NewP1Position}. Before it was {OldP1Position}");
            // Debug.Log($"p1_move_vector reset to {p1_move_vector.Value}");
        }

        Vector3 left = new Vector3(-1, 0, 0);
        Vector3 right = new Vector3(1, 0, 0);
        Vector3 up = new Vector3(0, 0, 1);
        Vector3 down = new Vector3(0, 0, -1);
        public void Move(){
            if (Input.GetKey(KeyCode.UpArrow)){
                MoveP1ServerRpc(up);
                // p1_move_vector.Value += up;
            }
            if (Input.GetKey(KeyCode.DownArrow)){
                MoveP1ServerRpc(down);
                // p1_move_vector.Value += down;
            }
            if (Input.GetKey(KeyCode.RightArrow)){
                MoveP1ServerRpc(right);
                // p1_move_vector.Value += right;
            }
            if (Input.GetKey(KeyCode.LeftArrow)){
                MoveP1ServerRpc(left);
                // p1_move_vector.Value += left;
            }
        }

        [ServerRpc]
        void MoveP1ServerRpc(Vector3 dir){
            Debug.Log("MoveP1 ServerRpc called");
            server.p1_Position.Value += (Vector3.Normalize(dir) / 10);
        }

        void Update()
        {   
            if (NetworkManager.Singleton.LocalClientId == 2){
                Move();
            }
        }
    }
}
