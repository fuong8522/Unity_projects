using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private float speed = 0.0f;
    private GameObject player;

    public float speedPro;
    void Start()
    {
        enemyRb= GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce( lookDirection* speed);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Vector3 lookDirection2 = (player.transform.position - transform.position).normalized;

        if(other.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("check");
            enemyRb.AddForce(lookDirection2 * -speedPro,ForceMode.Impulse);

        }
    }
}
