using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private GameObject focalPoint;
    private float powerUp = 50;
    public float speed = 4.0f;
    public bool hasPowerUp = false;
    public GameObject powreupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRB.AddForce(focalPoint.transform.forward * speed * forwardInput);
        if(hasPowerUp)
        {
            powreupIndicator.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }

    //If you want to do something with trigger and collider you need to use OnTriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            powreupIndicator.gameObject.SetActive(true);
            hasPowerUp = true;
            //Start thread for powerupcountdownroutine method
            StartCoroutine(PowerUpCountdownRoutine());
        }    
    }

    //IEnumerator create new thread outside of update
    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(3);
        hasPowerUp = false;
        powreupIndicator.gameObject.SetActive(false);
    }

    //If you want to do something with physics you need to use OnCollisionEnter
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * powerUp, ForceMode.Impulse);
        }
    }
}
