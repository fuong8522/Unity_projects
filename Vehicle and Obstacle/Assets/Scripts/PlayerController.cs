using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnspeed;

    private float horizontalInput;
    private float VerticalInput;
    void Start()
    {
        
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal1");
        VerticalInput = Input.GetAxis("Vertical1");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * VerticalInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnspeed * horizontalInput);
    }
}
