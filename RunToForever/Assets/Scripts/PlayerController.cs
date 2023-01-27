using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnimation;
    public ParticleSystem explosionParticle;
    public float jumForce = 25, gravityModifier;
    private bool isOnGround = true;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<Animator>();
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
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
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
        }
    }
}
