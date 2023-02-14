using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private Animator playerAnimation;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    public float jumForce = 25, gravityModifier;
    private bool isOnGround = true;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<Animator>();

        playerAudio = GetComponent<AudioSource>();
        //this multipication for faster fall after the jump;
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            //Like transform.transfer but more realistic movement like in real world
            playerRb.AddForce(Vector3.up * jumForce, ForceMode.Impulse);

            //Activate the jump animation which activated with Jump_trig value
            playerAnimation.SetTrigger("Jump_trig");
            isOnGround = false;

            //When jumping deactivate dirt particle
            dirtParticle.Stop();

            //Activate the jump auidio
            playerAudio.PlayOneShot(jumpSound, 1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            //When touch the ground start particle again
            dirtParticle.Play();
        }

        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");

            //Deactivate the jumping
            isOnGround = false;

            //Activate the death animation which activated with Death_b value
            playerAnimation.SetTrigger("Death_b");
            //Choiced first death animation which activated with DeathType_int equal 1
            playerAnimation.SetInteger("DeathType_int", 1);
            //Added particle system for death animation
            explosionParticle.Play();
            //Deactivate dirt particle when player death
            dirtParticle.Stop();

            //Activate the crash sound
            playerAudio.PlayOneShot(crashSound, 1);
        }
    }
}
