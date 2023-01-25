using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBound : MonoBehaviour
{
    public float upperBound = 30, lowerBound = -10, leftBound = -25, rightBound = 25;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > upperBound || transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
        else if(transform.position.z < lowerBound || transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
