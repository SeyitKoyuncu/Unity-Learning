using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueValue = 1;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 14f;
    private SurfaceEffector2D surfaceEffector;
    private Rigidbody2D chrachterRB;
    float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        chrachterRB = GetComponent<Rigidbody2D>();
        surfaceEffector = GameObject.Find("Level Sprite Shapepe").GetComponent<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!FindObjectOfType<CrashDetector>().isCrash)
        {
            RotatePlayer();
            SpeedBoost();
        }

    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            chrachterRB.AddTorque(torqueValue);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            chrachterRB.AddTorque(-torqueValue);
        }
    }

    void SpeedBoost()
    {
        if(Input.GetKey(KeyCode.Space))
            surfaceEffector.speed = boostSpeed;

        else
            surfaceEffector.speed = baseSpeed;
    }
}
