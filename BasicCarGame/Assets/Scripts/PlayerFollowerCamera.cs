using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowerCamera : MonoBehaviour
{
    //we use this for added to vehicle in the unity for follow the vehicle
    //So we can take a vehicle referenca with this way
    public GameObject player;
    private bool cameraSwap = false;
    private Vector3 offsetDefault = new Vector3(0, 5, -7);
    private Vector3 offsetCameraPosition2 = new Vector3(0, 7, 20);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate() //Late Update is always called after Update, meaning that Update will have been called on every script before the first Late Update is called.
    {
        //Add offset to the camera behind the player by adding to the player's position
        if(cameraSwap == false)
        {
            transform.position = player.transform.position + offsetDefault;
            Debug.Log("Now camera is in default mode");
        }
            
        else
        {
            transform.position = player.transform.position + offsetCameraPosition2;
            Debug.Log("Now camera is in mode2");
        }
            
        if(Input.GetKey("space") && !cameraSwap)
            cameraSwap = true;

        else if(Input.GetKey("space") && cameraSwap)
            cameraSwap = false;
    }
}
