using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // This function is called when the enemy collides with another object
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is a bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletController bulletController = collision.gameObject.GetComponent<BulletController>();
            Color enemyColor = GetComponent<Renderer>().material.color;

            // Check if the bullet's color matches the enemy's color
            if (bulletController.bulletColor == enemyColor)
            {
                // Destroy the enemy and the bullet
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}