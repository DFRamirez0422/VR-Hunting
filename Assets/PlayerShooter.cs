using UnityEngine;
using UnityEngine.UI;

public class PlayerShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float shootForce = 20f;
    public float spawnDistance = 0.5f;

    [Header("Fire Rate")]
    public float fireCooldown = 0.2f;   
    private float nextShootTime = 0f;   

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryShoot();
        }
    }

    void TryShoot()
    {
        if (Time.time < nextShootTime)
            return;

        nextShootTime = Time.time + fireCooldown;

        Shoot();
    }

    void Shoot()
    {
        if (projectilePrefab == null) return;

        Vector3 spawnPos = transform.position + transform.forward * spawnDistance;

        GameObject proj = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
        Rigidbody rb = proj.GetComponent<Rigidbody>();

        rb.linearVelocity = transform.forward * shootForce;
    }
}
