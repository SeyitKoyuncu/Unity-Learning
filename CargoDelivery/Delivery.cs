using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor, noPackageColor;
    bool isPacketTaken = false;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(collision.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // if the trigger thing is package take it 
        if(collision.gameObject.CompareTag("package") && !isPacketTaken)
        {
            isPacketTaken = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject);
            Debug.Log("Packed is picked by car");
        }

        if (collision.gameObject.CompareTag("customer") && isPacketTaken)
        {
            spriteRenderer.color = noPackageColor;
            isPacketTaken = false;
            Debug.Log("Packed delivered");
        }
    }

    static byte ReturnRandomColorByte()
    {
        return (byte)Random.Range(0.0f, 1.0f);
    }

}
