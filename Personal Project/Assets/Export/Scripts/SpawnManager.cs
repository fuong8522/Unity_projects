using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject powerUp;
    public GameObject[] enemy;

    private float rangeX = 22.0f;
    private float rangeZ = 15.0f;
    private float rangeZpowerup = 8.0f;
    private float delayStart = 1.0f;
    private float intervalsEnemy = 1.0f;
    private float intervalsPowerup = 6.0f;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", delayStart, intervalsEnemy);
        InvokeRepeating("SpawnPowerup", delayStart, intervalsPowerup);
    }

    void SpawnEnemy()
    {
        float spawnX = Random.Range(-rangeX, rangeX);
        int index = Random.Range(0,enemy.Length);
        Vector3 spawnPos = new Vector3(spawnX, 0.8f, rangeZ);

        Instantiate(enemy[index], spawnPos, enemy[index].transform.rotation);
    }
    void SpawnPowerup()
    {
        float spawnX = Random.Range(-rangeX, rangeX);
        float spawnZ = Random.Range(-rangeZpowerup, rangeZpowerup);
        Vector3 spawnPos = new Vector3(spawnX, 0.5f, spawnZ);

        Instantiate(powerUp, spawnPos, powerUp.transform.rotation);
    }

}
