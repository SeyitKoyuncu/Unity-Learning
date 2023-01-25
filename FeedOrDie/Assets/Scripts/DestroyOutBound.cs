using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBound : MonoBehaviour
{
    public float upperBound = 30, lowerBound = -10, leftBound = -25, rightBound = 25;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > upperBound || transform.position.x > rightBound)
        {
            Destroy(gameObject);
            if (PlayerController.DecreaseLife() <= 0) Debug.Log("Game Over");
        }
        else if(transform.position.z < lowerBound || transform.position.x < leftBound)
        {
            Destroy(gameObject);
            if (PlayerController.DecreaseLife() <= 0) Debug.Log("Game Over");
        }
    }
}
