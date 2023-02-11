using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 8;
    public float doubleJumpForce = 4;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;

    public AudioSource audioCam;
    private AudioSource audioPlayer;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private bool doubleJump;
    public bool doubleSpeed = false;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        doubleJump = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround  && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);

            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;
            dirtParticle.Stop();
            audioPlayer.PlayOneShot(jumpSound, 1.0f);
            doubleJump = true;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && doubleJump && !isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;
            dirtParticle.Stop();
            audioPlayer.PlayOneShot(jumpSound, 1.0f);
            doubleJump = false;
        }

        if(Input.GetKey(KeyCode.LeftShift)) 
        {
            doubleSpeed = true;
            playerAnim.SetFloat("Speed_Multiplier", 2);
        }
        else
        {
            playerAnim.SetFloat("Speed_Multiplier", 1);
            doubleSpeed = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            dirtParticle.Stop();
            Debug.Log("Game over !");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            audioPlayer.PlayOneShot(crashSound, 1.0f);
            explosionParticle.Play();
            audioCam.Stop();
            
        }
    }
}
