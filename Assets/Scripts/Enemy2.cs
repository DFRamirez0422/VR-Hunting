using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public int points = 50; // editable in inspector

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);

            // Add points to score
            FindObjectOfType<ScoreManager>()?.AddScore(points);

            // Respawn Cube2
            FindObjectOfType<GameManager>()?.RespawnEnemy2();
        }
    }
}
