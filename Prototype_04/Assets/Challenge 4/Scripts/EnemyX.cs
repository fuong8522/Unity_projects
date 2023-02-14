using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public GameObject spawnManager;
    public float speed;
    private Rigidbody enemyRb;
    public GameObject playerGoal;

    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager X");
        speed = spawnManager.GetComponent<SpawnManagerX>().speedEnemy;
        Debug.Log(speed);
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");
    }

    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
