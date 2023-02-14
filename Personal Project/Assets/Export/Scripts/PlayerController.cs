using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody playerRb;
    private float horizontalInput;
    private float verticalInput;

    private float boundRight = 22;
    private float boundUp = 8;

    void Start()
    {
        playerRb= GetComponent<Rigidbody>();
    }

    void Update()
    {
        UserInput();
        ConstrainX();
        ConstrainZ();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    //Arrow key input
    void UserInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    //Move the player based on arrow key input
    void MovePlayer()
    {
        playerRb.AddForce(new Vector3(horizontalInput, 0, verticalInput) * speed);
    }
    //Prevent the player from leaving the top or bottom of the screen
    void ConstrainZ()
    {
        //Constrain by axes z
        if (transform.position.z < -boundUp)
        {
            transform.position = new Vector3(transform.position.x, 0.5f, -boundUp);
        }
        else if (transform.position.z > boundUp)
        {
            transform.position = new Vector3(transform.position.x, 0.5f, boundUp);
        }
    }
    //Prevent the player from leaving the left or right of the screen 
    void ConstrainX()
    {
        //Constrain by axes x
        if (transform.position.x < -boundRight)
        {
            transform.position = new Vector3(-boundRight, 0.5f, transform.position.z);
        }
        else if (transform.position.x > boundRight)
        {
            transform.position = new Vector3(boundRight, 0.5f, transform.position.z);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collied with enemy");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }
}
