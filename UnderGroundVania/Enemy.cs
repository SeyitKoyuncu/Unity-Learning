using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D enemyRb;


    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        enemyRb.velocity = new Vector2(moveSpeed, 0);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    }

    void FlipEnemyFacing()
    {
        bool enemyHasHorizontalSpeed = Mathf.Abs(enemyRb.velocity.x) > Mathf.Epsilon;

        transform.localScale = new Vector2(-Mathf.Sign(enemyRb.velocity.x), 1f); ;
    }
}
