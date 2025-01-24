// PlayerMovement.cs
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float boundaryPadding = 0.5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float shootCooldown = 0.5f;

    private float screenWidth;
    private float shootTimer = 0f;

    void Start()
    {
        // Calculate screen width in world units
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    void HandleMovement()
    {
        // Get horizontal input
        float inputX = InputManager.Instance.Joystick_Horizontal;
        float inputY = InputManager.Instance.Joystick_Vertical;

        // Move the player
        Vector3 movement = new Vector3(inputX * speed * Time.deltaTime, inputY * speed * Time.deltaTime, 0);

        transform.position += movement;

        // Clamp position to bottom of the screen
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 1.0f, 4.0f), transform.position.z);

        // Clamp position within screen bounds
        float clampedX = Mathf.Clamp(transform.position.x, 0 + boundaryPadding, screenWidth * 2 - boundaryPadding);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    void HandleShooting()
    {
        // Update shoot timer
        shootTimer -= Time.deltaTime;

        if (Input.GetKey(InputManager.Instance.Button_BottomLeft) && shootTimer <= 0f)
        {
            Shoot();
            shootTimer = shootCooldown;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
    }
}
