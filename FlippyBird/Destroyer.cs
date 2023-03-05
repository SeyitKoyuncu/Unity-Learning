using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] float destroyOffsetX = 10;
    [SerializeField] GameObject player;
    void Update()
    {
        if(destroyOffsetX > Mathf.Abs(gameObject.transform.position.x - player.transform.position.x))
        {
            Destroy(gameObject);
        }
    }
} 
