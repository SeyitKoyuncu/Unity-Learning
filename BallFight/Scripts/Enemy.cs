using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody enemyRB;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //player.transform.position - transform.position is give us to distance vector
        //When normalized, a vector keeps the same direction but its length is 1.0
        //So with normalized we change distance magnitude to the 1.0 but direction is the same 
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(lookDirection * speed);
        if (transform.position.y < -3)
            Destroy(gameObject);
    }
}
