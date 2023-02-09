using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DetectCollisionsX : MonoBehaviour
{
    private static int Score;
    private void OnTriggerEnter(Collider other)
    {
        Score++;
        Debug.Log(Score);
        Destroy(gameObject);
    }
}
