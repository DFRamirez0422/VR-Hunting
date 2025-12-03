using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int points = 10; // editable in inspector

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);

            // Add points to score
            FindObjectOfType<ScoreManager>()?.AddScore(points);

            // Respawn Cube1
            FindObjectOfType<GameManager>()?.RespawnEnemy1();
        }
    }
}
