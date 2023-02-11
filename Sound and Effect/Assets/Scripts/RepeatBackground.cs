using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if(transform.position.x < startPos.x -56.4f)
        {
            transform.position = startPos;
        }
    }
}
