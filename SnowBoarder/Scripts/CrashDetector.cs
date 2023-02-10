using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] AudioClip crashSFX;
    public bool isCrash = false;

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
        if (collision.tag == "Ground" && !isCrash) 
        {
            isCrash = true;
            crashParticle.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", 1.0f);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
