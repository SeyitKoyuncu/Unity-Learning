using System.Threading;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //with pubic access modifier we can see this variable in the unity
    public float speed = 5.0f;
    public float turnSpeed = 25.0f;
    public float horizontalInput;
    public float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Move the vehicle forward
        //transform.Translate(0, 0 , 1);

        //Go forward 20 meters in second
        transform.Translate(UnityEngine.Vector3.forward * Time.deltaTime * speed * verticalInput);
        
        //transform.Translate(UnityEngine.Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        transform.Rotate(UnityEngine.Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
