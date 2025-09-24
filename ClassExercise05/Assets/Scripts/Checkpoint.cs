using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // When the player passes a checkpoint, destroy it
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
