using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectColisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    //In unity when one collider colide with other collider, unity know it and when this time call the this method
    //Overriding from MonoBehaviiour
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        int score = PlayerController.AddScore();
        Debug.Log($"Score = {score}");
    }
}
