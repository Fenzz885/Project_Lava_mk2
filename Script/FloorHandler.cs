using UnityEngine;

public class FloorHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lava"))
        {
            Destroy(gameObject);
        }
    }
}