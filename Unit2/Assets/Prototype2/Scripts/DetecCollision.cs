using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetecCollision : MonoBehaviour
{
    private TextMeshProUGUI textScore;
    private static int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        score++;
        Destroy(gameObject);
        Destroy(other.gameObject);
        Debug.Log(score);
    }
}
