using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject projectile;
    public bool hasPowerup = false;
    public bool hasPowerup2 = false;
    public int time = 7;
    public GameObject powerupIndicator;
    public GameObject powerupIndicator2;

    private GameObject focalPoint;
    private Rigidbody playerRb;
    private float powerUpStrength = 15.0f;
    private float powerEnemy2 = 5.0f;
    private bool projectiled = false;
    void Start()
    {
        focalPoint = GameObject.Find("Focal Point");
        playerRb = GetComponent<Rigidbody>();   
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0,-0.65f,0);
        powerupIndicator2.transform.position = transform.position + new Vector3(0,-0.65f,0);

        if (hasPowerup2 && projectiled)
        {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
            projectiled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
        }
        else if (other.CompareTag("Powerup 2"))
        {
            hasPowerup2 = true;
            powerupIndicator2.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
            projectiled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            
            Debug.Log("Collied with: " + collision.gameObject.name + " with has Powerup !");

            Rigidbody rigidEnemy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 directionFly = collision.transform.position - transform.position;
            rigidEnemy.AddForce(directionFly * powerUpStrength, ForceMode.Impulse);
        }
        if(collision.gameObject.CompareTag("Enemy2") && hasPowerup)
        {
            
            Debug.Log("Collied with: " + collision.gameObject.name + " with has Powerup !");

            Rigidbody rigidEnemy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 directionFly = collision.transform.position - transform.position;
            rigidEnemy.AddForce(directionFly * powerUpStrength * 2, ForceMode.Impulse);
        }
        else if(collision.gameObject.CompareTag("Enemy2"))
        {
            Vector3 directionFly = transform.position - collision.transform.position;
           playerRb.AddForce(directionFly * powerEnemy2, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(time);
        hasPowerup = false;
        hasPowerup2 = false;
        powerupIndicator.gameObject.SetActive(false);
        powerupIndicator2.gameObject.SetActive(false);
    }
}
