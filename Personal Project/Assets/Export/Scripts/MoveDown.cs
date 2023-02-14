using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 20.0f;
    private Rigidbody obstacleRb;
    private float zDestroy = -10.0f;
    void Start()
    {
        obstacleRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        obstacleRb.AddForce(Vector3.forward * -speed);

        if(transform.position.z < zDestroy) 
        {
            Destroy(gameObject);
        }
    }


}
