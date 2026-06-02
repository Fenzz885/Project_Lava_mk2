using UnityEngine;

public class FireballSpawner : MonoBehaviour
{
    public GameObject fireballPrefab; // Masukkan prefab bola api di sini
    public float spawnRate = 2f; // Muncul setiap 2 detik
    private float nextSpawn = 0f;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            // Munculkan bola api di posisi spawner
            Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        }
    }
}