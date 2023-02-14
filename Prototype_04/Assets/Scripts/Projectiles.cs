using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speedProjectile;
    private GameObject[] enemy;
    private GameObject player;
    private Vector3 direction;
    void Start()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
        direction = player.transform.position - enemy[0].transform.position;
        direction.y= 0;
    }

    void Update()
    {
        transform.Translate( direction.normalized * -speedProjectile * Time.deltaTime,Space.World);
    }
    
}
