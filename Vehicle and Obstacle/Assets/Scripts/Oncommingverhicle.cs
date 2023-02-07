using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oncommingverhicle : MonoBehaviour
{
    public float speed_verhicle;

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed_verhicle * -1 * 5);
    }
}
