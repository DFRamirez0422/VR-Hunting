using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 5f; // optional auto-destroy after 5 seconds

    void Start()
    {
        Destroy(gameObject, lifetime); // remove projectile after 5 seconds if it doesn't hit anything
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); // destroy projectile on any collision
    }
}
