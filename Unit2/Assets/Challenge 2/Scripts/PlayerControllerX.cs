using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float count = 0;

    private void Start()
    {
        count = 1;
    }

    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (count >= 1)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                count = 0;
            }
        }
        count += Time.deltaTime;
    }
}
