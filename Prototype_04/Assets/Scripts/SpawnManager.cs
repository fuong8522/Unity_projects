using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefab;
    public float spawnRange = 9;
    private int spawnCount = 1;
    public int countOfEnemy;
    public GameObject[] powerupPrefab;
    void Start()
    {
        SpawnWave(spawnCount);
        Instantiate(powerupPrefab[1], GenerateRandom(), powerupPrefab[1].transform.rotation);
    }

    void Update()
    {
        countOfEnemy = FindObjectsOfType<Enemy>().Length;
        if(countOfEnemy == 0)
        {
            spawnCount++;
            SpawnWave(spawnCount);
            int indexPowerup = Random.Range(0,powerupPrefab.Length);
            Instantiate(powerupPrefab[indexPowerup], GenerateRandom(), powerupPrefab[indexPowerup].transform.rotation);
        }
    }

    void SpawnWave(int Count)
    {
        int index = Random.Range(0, prefab.Length);
        for(int i = 0;i< Count;i++)
        {
            Instantiate(prefab[index], GenerateRandom(), prefab[index].transform.rotation);
        }
    }
    private Vector3 GenerateRandom()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnX, 0, spawnZ);
        return spawnPos;
    }
}
