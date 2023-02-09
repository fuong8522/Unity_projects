using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpawn : MonoBehaviour
{
    public GameObject prefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 1;
    private float timeRate = 3;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, timeRate);
    }


    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        Instantiate(prefabs, spawnPos, prefabs.transform.rotation);

    }
}
