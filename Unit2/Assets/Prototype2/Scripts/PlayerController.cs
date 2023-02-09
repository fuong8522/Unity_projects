using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float speed;
    public float xrange;
    public float zrange;
    public GameObject projectilePrefab;
    void Update()
    {
        if (transform.position.x < -xrange)
        {
            transform.position = new Vector3(-xrange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xrange)
        {
            transform.position = new Vector3(xrange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zrange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zrange);
        }
        else if (transform.position.z > zrange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zrange);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position + new Vector3(0, 1, 1), projectilePrefab.transform.rotation);
        }

    }
}
