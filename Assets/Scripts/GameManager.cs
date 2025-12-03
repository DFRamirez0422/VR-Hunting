using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab1; // original Cube
    public GameObject enemyPrefab2; // new Cube2
    public Vector3 spawnPos1 = new Vector3(0, 1, 5);
    public Vector3 spawnPos2 = new Vector3(2, 1, 5); // start somewhere different
    public float respawnDelay = 1f;

    void Start()
    {
        SpawnEnemy1();
        SpawnEnemy2();
    }

    // Spawn methods
    public void SpawnEnemy1()
    {
        Instantiate(enemyPrefab1, spawnPos1, Quaternion.identity);
    }

    public void SpawnEnemy2()
    {
        Instantiate(enemyPrefab2, spawnPos2, Quaternion.identity);
    }

    // Respawn methods
    public void RespawnEnemy1()
    {
        StartCoroutine(Respawn1());
    }

    IEnumerator Respawn1()
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnEnemy1();
    }

    public void RespawnEnemy2()
    {
        StartCoroutine(Respawn2());
    }

    IEnumerator Respawn2()
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnEnemy2();
    }
}
