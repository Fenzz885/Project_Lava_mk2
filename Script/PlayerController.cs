using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Pergerakan Kanan Kiri
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Lompat
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    // Fungsi deteksi tabrakan (Lantai)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek tabrakan dengan Lava atau Rintangan
        if (other.CompareTag("Lava") || other.CompareTag("Obstacle"))
        {
            GameManager gm = FindAnyObjectByType<GameManager>();
            if (gm != null) gm.EndGame();

            Destroy(gameObject); // Bayi hilang jika kalah
        }
        // Cek jika menyentuh Garis Finish
        else if (other.CompareTag("Finish"))
        {
            GameManager gm = FindAnyObjectByType<GameManager>();
            if (gm != null) gm.WinGame();
        }
    }
} // <--- Pastikan kurung kurawal penutup ini ada di paling bawah!