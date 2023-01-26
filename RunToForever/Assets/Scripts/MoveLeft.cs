using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerController playerController;
    public float leftBound = -5;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerController.gameOver)
            transform.Translate(Vector3.left * UnityEngine.Time.deltaTime * speed);

        DeleteObstacles();
    }
    void DeleteObstacles()
    {
        if (leftBound > gameObject.transform.position.x && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}
