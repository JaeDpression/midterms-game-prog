void OnCollisionEnter2D(Collision2D collision)
{
    // Check if the bullet collided with an enemy
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