using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableCamera : MonoBehaviour
{
    [SerializeField] GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //LateUpdate is called after all Update functions have been called.
    void LateUpdate()
    {
        transform.position = car.transform.position + new Vector3(0,0,-10); 
    }
}
