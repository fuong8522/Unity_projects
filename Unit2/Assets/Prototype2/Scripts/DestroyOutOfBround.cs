using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBround : MonoBehaviour
{
    private static int live = 3;
    void Update()
    {
        if (transform.position.z > 30)
        {
            Destroy(gameObject);
        }

        else if (transform.position.z < -10)
        {
            //If an object goes past the player view in the game, remove that object.
            if(live == 0) 
            {
                Debug.Log("Game Over !");
            }
            Debug.Log(live);
            live--;
            Destroy(gameObject);
        }
        else if (transform.position.x < -35)
        {
            Destroy(gameObject);
            //If an object goes past the player view in the game, remove that object.

        }
        else if (transform.position.x > 35)
        {
            Destroy(gameObject);
        }
    }
}
