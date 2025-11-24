using UnityEngine;
using UnityEngine.UI;

public class PlayerShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float shootForce = 20f;
    public Text feedbackText;
    public float spawnDistance = 0.5f; // distance in front of camera

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (projectilePrefab == null) return;

        // Spawn slightly in front of camera to avoid hitting player
        Vector3 spawnPos = transform.position + transform.forward * spawnDistance;

        GameObject proj = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
        Rigidbody rb = proj.GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * shootForce;
    }
}
