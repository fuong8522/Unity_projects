using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpawn : MonoBehaviour
{
    public GameObject[] animals;
    private float spawnRangeX = 20;
    private float startDelay = 3;
    private float spawnInterval = 1.5f;

    private void Start()
    {
        InvokeRepeating("SpawnAnimals",startDelay,spawnInterval);
        InvokeRepeating("SpawnRightAnimals",5,8);
        InvokeRepeating("SpawnLeftAnimals",10,6);
    }
    void Update()
    {

    }

    void SpawnAnimals()
    {
        int index = Random.Range(0, animals.Length);
        Vector3 SpawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, 25);
        Instantiate(animals[index], SpawnPos, animals[index].transform.rotation);
    }

    void SpawnRightAnimals()
    {
        int index = Random.Range(0, animals.Length);

        Vector3 SpawnPos = new Vector3(30, 0, Random.Range(-3,3));

        Instantiate(animals[index], SpawnPos, Quaternion.Euler(0, -90, 0));
    }
    void SpawnLeftAnimals()
    {
        int index = Random.Range(0, animals.Length);

        Vector3 SpawnPos = new Vector3(-30, 0, Random.Range(-3,3));

        Instantiate(animals[index], SpawnPos, Quaternion.Euler(0, 90, 0));
    }
}
