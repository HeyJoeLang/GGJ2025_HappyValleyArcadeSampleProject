// BulletMovement.cs
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f;
    float maxHeight = 11f;
    void Update()
    {
        // Move the bullet upward
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Destroy bullet if it goes out of screen bounds
        if (transform.position.y > maxHeight)
        {
            Destroy(gameObject);
        }
    }
}
