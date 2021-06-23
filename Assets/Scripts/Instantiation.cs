using UnityEngine;
public class Instantiation : MonoBehaviour 
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject ball;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Vector3 v = new Vector3(Random.Range(-3f, 3f), 1f, Random.Range(-3f, 3f));
        // Instantiate(ball, v, Quaternion.identity);
    }
}
