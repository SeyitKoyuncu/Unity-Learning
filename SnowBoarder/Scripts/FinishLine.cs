using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem finishParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            finishParticle.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReleodScene", 1.0f);
        }
            
    }

    void ReleodScene()
    {
        SceneManager.LoadScene(0);
    }
}
