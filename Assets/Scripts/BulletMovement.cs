using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f; // Speed at which the bullet moves

    void Update()
    {
        // Move the bullet
        transform.position += Vector3.up * speed * Time.deltaTime;

        // Destroy the bullet if it goes off-screen
        if (transform.position.y > Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy the bullet if it hits an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}