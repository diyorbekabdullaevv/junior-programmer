using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRangeX = 10;
    private float spawnZMin = 15;
    private float spawnZMax = 25;

    public int enemyCount;
    public int waveCount = 1;

    public GameObject player;

    // Enemy speed
    public float enemySpeed = 10f;

    // Speed increase for every new wave
    public float speedIncrease = 1f;

    // Update is called once per frame
    void Update()
    {
        // Count the enemies currently in the scene
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // If all enemies are gone, spawn a new wave
        if (enemyCount == 0)
        {
            SpawnEnemyWave(waveCount);
        }
    }

    // Generate random spawn position
    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);

        return new Vector3(xPos, 0, zPos);
    }

    // Spawn a new wave
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        Vector3 powerupSpawnOffset = new Vector3(0, 0, -15);

        // If no powerup exists, spawn one
        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0)
        {
            Instantiate(
                powerupPrefab,
                GenerateSpawnPosition() + powerupSpawnOffset,
                powerupPrefab.transform.rotation
            );
        }

        // Spawn the correct number of enemies
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject newEnemy = Instantiate(
                enemyPrefab,
                GenerateSpawnPosition(),
                enemyPrefab.transform.rotation
            );

            // Give the enemy the current speed
            newEnemy.GetComponent<EnemyX>().speed = enemySpeed;
        }

        // Increase speed for the NEXT wave
        enemySpeed += speedIncrease;

        // Increase wave number
        waveCount++;

        // Reset player position
        ResetPlayerPosition();
    }

    // Move player back to starting position
    void ResetPlayerPosition()
    {
        player.transform.position = new Vector3(0, 1, -7);

        player.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
