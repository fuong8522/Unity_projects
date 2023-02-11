using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public float score;
    public Transform startingPoint;
    public float lerpSpeed;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0;
        playerControllerScript.gameOver = true;
        StartCoroutine(PlayIntro());
    }

    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (playerControllerScript.doubleSpeed)
                {
                    score += 2;
                }
                score++;
                Debug.Log("Score: " + score);

            }
        }
    }

    IEnumerator PlayIntro()
    {
        Vector3 startPos = playerControllerScript.transform.position;
        Vector3 endPos = startingPoint.position;
        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;
        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;
        playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier",
        0.2f);
        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLength;
            playerControllerScript.transform.position = Vector3.Lerp(startPos, endPos,
            fractionOfJourney);
            yield return null;
        }
        playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier",
1.0f);
        playerControllerScript.gameOver = false;
    }
}
