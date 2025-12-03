using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject projectilePrefab;
    public float shootForce = 20f;
    public float spawnDistance = 0.5f;

    [Header("Ammo Settings")]
    public int maxAmmo = 5;
    public float reloadTime = 2f;

    [Header("UI")]
    public Slider reloadSlider;
    public Text statusText;

    private int currentAmmo;
    private bool isReloading = false;

    //NEW: global shooting lock after timer ends
    private bool shootingDisabled = false;

    private float reloadTimer = 0f;

    void Start()
    {
        currentAmmo = maxAmmo;
        reloadSlider.maxValue = 1f;
        reloadSlider.value = 1f;
        UpdateStatusText();
    }

    void Update()
    {
        //Prevent any shooting or reloading logic after timer ends
        if (shootingDisabled)
            return;

        if (!isReloading && Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (isReloading)
        {
            reloadTimer += Time.deltaTime;
            reloadSlider.value = reloadTimer / reloadTime;
            statusText.text = "RELOADING";

            if (reloadTimer >= reloadTime)
                FinishReload();
        }
    }

    void Shoot()
    {
        if (currentAmmo <= 0)
        {
            StartReload();
            return;
        }

        Vector3 spawnPos = transform.position + transform.forward * spawnDistance;
        GameObject proj = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);

        Rigidbody rb = proj.GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * shootForce;

        currentAmmo--;
        reloadSlider.value = (float)currentAmmo / maxAmmo;

        if (currentAmmo == 0)
            StartReload();
        else
            UpdateStatusText();
    }

    void StartReload()
    {
        isReloading = true;
        reloadTimer = 0f;
        reloadSlider.value = 0f;
        statusText.text = "RELOADING";
    }

    void FinishReload()
    {
        isReloading = false;
        currentAmmo = maxAmmo;
        reloadSlider.value = 1f;
        UpdateStatusText();
    }

    void UpdateStatusText()
    {
        statusText.text = "Ammo: " + currentAmmo + "/" + maxAmmo;
    }

    //NEW FUNCTION — called when timer ends
    public void DisableShooting()
    {
        shootingDisabled = true;
        isReloading = false;

        // Blank UI
        statusText.text = "";
        reloadSlider.value = 0f;
    }

    public void ResetAmmoAndEnable()
    {
        shootingDisabled = false;
        isReloading = false;
        currentAmmo = maxAmmo;

        if (reloadSlider != null)
            reloadSlider.value = 1f;

        if (statusText != null)
            statusText.text = currentAmmo + "/" + maxAmmo;
    }

}
