using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
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
        horizontalInput = Input.GetAxis("Horizontal2");
        VerticalInput = Input.GetAxis("Vertical2");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * VerticalInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnspeed * horizontalInput);
    }
}
