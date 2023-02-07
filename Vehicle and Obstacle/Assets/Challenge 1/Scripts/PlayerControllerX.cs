using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float turnpropeller;
    public GameObject propeller;
    public float rotationSpeed;
    private float verticalInput;

    void Start()
    {

    }

    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime * verticalInput);
    }
    private void Update()
    {
        propeller.transform.Rotate(0, 0, turnpropeller);
    }
}
