using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float turnSpeed = 100f, moveSpeed = 10f;
    float horizontalInut, verticalInput;
    [SerializeField] float slowSpeed = 10, boostSpeed = 30;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInut = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(0, 0, -horizontalInut * turnSpeed * Time.deltaTime);
        transform.Translate(0, verticalInput * moveSpeed * Time.deltaTime , 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("boost"))
        {
            moveSpeed = boostSpeed;
        }

        else if(collision.CompareTag("slow"))
        {
            moveSpeed = slowSpeed;
        }
    }
}
