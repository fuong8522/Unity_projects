using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset;

    void Start()
    {
        offset = plane.transform.position - transform.position;
    }

    void LateUpdate()
    {
        transform.position = plane.transform.position - offset;
    }
}
