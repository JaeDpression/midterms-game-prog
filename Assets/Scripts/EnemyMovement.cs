using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player; // Reference to the player object
    public Vector2 direction; // Direction of the enemy movement
    public float enemySpeed = 2f; // Speed at which the enemy moves towards the player
    public delegate void OnDestroyEvent();
    public event OnDestroyEvent onDestroy;

    private void Update()
    {
        // Move the enemy towards the player
        transform.Translate(direction * enemySpeed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        // Call the OnDestroy event
        if (onDestroy != null)
        {
            onDestroy();
        }
    }
}