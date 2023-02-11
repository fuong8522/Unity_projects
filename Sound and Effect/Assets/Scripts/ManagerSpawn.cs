using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpawn : MonoBehaviour
{
    public GameObject[] prefabsObstacle;
    private Vector3 spawnPos = new Vector3(40, 0, 0);
    private float startDelay = 1;
    private float timeRate = 3;

    private PlayerController playerControllerScript;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, timeRate);
    }


    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            int index = Random.Range(0, prefabsObstacle.Length);
            Instantiate(prefabsObstacle[index], spawnPos, prefabsObstacle[index].transform.rotation);
        }

    }
}
