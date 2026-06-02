using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Tarik objek Player ke sini di Inspector
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 2, -10); // Biar kamera agak di atas bayi

    void LateUpdate()
    {
        if (target != null)
        {
            // Kamera hanya mengikuti posisi Y (tinggi) si bayi
            Vector3 desiredPosition = new Vector3(transform.position.x, target.position.y + offset.y, offset.z);
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
    }
}