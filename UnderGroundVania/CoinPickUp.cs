using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField] AudioClip coinpPickupSFX;
    [SerializeField] int pointsForCoinPickUp = 10;

    bool wasCollected =false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickUp);
            AudioSource.PlayClipAtPoint(coinpPickupSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
