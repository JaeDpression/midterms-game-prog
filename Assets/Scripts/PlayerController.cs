using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Color[] colors = new Color[] { Color.red, Color.blue, Color.green }; // Colors to cycle through
    private int colorIndex = 0; // Current color index
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer
    public GameObject bulletPrefab; // Bullet prefab
    public float shootInterval = 1f; // Shooting interval in seconds

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer
        spriteRenderer.color = colors[colorIndex]; // Set initial color
        StartCoroutine(ShootBullets()); // Start the shooting coroutine
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeColor();
        }
    }

    void ChangeColor()
    {
        colorIndex = (colorIndex + 1) % colors.Length; // Cycle through colors
        spriteRenderer.color = colors[colorIndex]; // Update the player's color
        Debug.Log("Changed color to: " + spriteRenderer.color); // Log the new color
    }

    IEnumerator ShootBullets()
    {
        while (true)
        {
            ShootBullet(); // Shoot a bullet
            yield return new WaitForSeconds(shootInterval); // Wait for the shooting interval
        }
    }

    void ShootBullet()
    {
        Debug.Log("ShootBullet called");
        // Create a new bullet object
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Debug.Log("Bullet instantiated: " + bullet);

        // Set the bullet's color to match the player's color
        SpriteRenderer bulletSpriteRenderer = bullet.GetComponent<SpriteRenderer>();
        bulletSpriteRenderer.color = spriteRenderer.color;
        Debug.Log("Bullet color set: " + bulletSpriteRenderer.color);

        // Set the bullet's velocity
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = new Vector2(10f, 0f);
        Debug.Log("Bullet velocity set: " + bulletRb.velocity);

        // Set the bullet's lifetime
        Destroy(bullet, 2f); // Destroy the bullet after 2 seconds
        Debug.Log("Bullet lifetime set: 2 seconds");
    }
}