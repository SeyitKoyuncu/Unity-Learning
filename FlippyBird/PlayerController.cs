using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpAmount = 5.0f;
    [SerializeField] float speed = 3.0f;
    [SerializeField] float destroyOffset = 6;

    Rigidbody2D playerRB;
    float jumpInput;
    bool isAlive;
    int score = 0;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        isAlive = true;
    }

    void Update()
    {
        if (isAlive)
        {
            Jump();
            Run();
        }

        if (transform.position.y < -destroyOffset)
            Destroy(gameObject);
    }

    void Jump()
    {
        if (isAlive && Input.GetKeyDown(KeyCode.Space))
            playerRB.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
    }

    void Run()
    {
        if (isAlive)
        {
            Vector3 newPosition = new Vector3(transform.position.x + (speed * Time.deltaTime * -1), transform.position.y, transform.position.z);
            gameObject.transform.position = newPosition;
        }
    }

    void Die()
    {
        Debug.Log("Player die method");
        isAlive = false;
    }

    public int GetScore() { return score; }
    public void SetScore(int additionScore) { score += additionScore; }

    public bool GetIsAlive() { return isAlive; }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" && isAlive)
        {
            Die();
        }
    }
}
