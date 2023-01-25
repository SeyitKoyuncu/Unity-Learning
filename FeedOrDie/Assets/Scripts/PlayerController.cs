using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput, verticalInput;
    public float speed = 15;
    public float xRange = 10.0f, zRange = 10.0f;
    public int score = 0;


    //you need to add this obejct to the prefab, if you try to add hieararchy object
    //when you need more food(spawn them) your game will be broked by them
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

        else if(transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        if(transform.position.z > zRange)
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);

        else if(transform.position.z < -zRange)
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);


        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * UnityEngine.Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * UnityEngine.Time.deltaTime * speed);

        if(Input.GetKeyDown(KeyCode.Space) && projectilePrefab)
        {
            //Instantiate for creating copys of objects that already of exist
            //We create projectilePrefab in line 13 now we copy i
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
