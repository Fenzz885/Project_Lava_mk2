using UnityEngine;

public class MusikTerus : MonoBehaviour
{
    private static MusikTerus instance;

    void Awake()
    {
        // Cek apakah sudah ada musik yang jalan
        if (instance == null)
        {
            instance = this;
            // Perintah agar objek ini TIDAK hancur saat pindah scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Kalau sudah ada musik dari scene sebelumnya, hapus yang baru ini
            // Biar lagunya tidak jadi double (tumpang tindih)
            Destroy(gameObject);
        }
    }
}