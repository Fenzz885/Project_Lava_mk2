using UnityEngine;

public class LavaRising : MonoBehaviour
{
    public float riseSpeed = 0.5f;

    void Update()
    {
        // Tetap naik ke atas
        transform.Translate(Vector2.up * riseSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // PASTIKAN: Hanya hancurkan jika benda itu punya Tag "Ground"
        // Dan pastikan benda itu BUKAN si lava ini sendiri
        if (other.CompareTag("Ground"))
        {
            Destroy(other.gameObject);
            Debug.Log("Lantai " + other.name + " berhasil tertelan lava!");
        }

    }
}