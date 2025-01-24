// EnemyBehavior.cs
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed = 3f;
    public int damage = 1;
    public GameObject explosionPrefab;

    void Update()
    {
        // Move the enemy downward
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Destroy the enemy if it goes out of screen bounds
        if (transform.position.y < -Camera.main.orthographicSize - 1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check for collision with the player
        if (other.CompareTag("Player"))
        {
            PlayerHealthAndScore.TakeDamage(damage);
            if (PlayerHealthAndScore.GetHealth() <= 0)
            {
                Destroy(other.gameObject);
            }
            Explode();
        }

        // Check for collision with a bullet
        if (other.CompareTag("Bullet"))
        {
            GameObject spawnedExplosion = GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(spawnedExplosion, 0.95f);
            // Destroy both the bullet and the enemy
            Destroy(other.gameObject);
            Explode();
            PlayerHealthAndScore.AddScore(10);
        }
    }
    void Explode()
    {
        GameObject spawnedExplosion = GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(spawnedExplosion, 0.95f);
        Destroy(gameObject);
    }
}
