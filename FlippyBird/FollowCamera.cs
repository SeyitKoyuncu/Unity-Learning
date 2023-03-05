using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] float offset = 5;
    [SerializeField] GameObject player;

    PlayerController playerController;

    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void LateUpdate()
    {
        if(playerController.GetIsAlive())
        {
            Vector3 newPosition = new Vector3(player.transform.position.x - offset, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}
