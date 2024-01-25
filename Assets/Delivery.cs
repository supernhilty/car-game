using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(0,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 0, 0,1);
    bool hasPackage;
    [SerializeField] float destroyDelay =0.5f;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package"&&!hasPackage)
        {
            Debug.Log("Get the package");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject, destroyDelay);
        }
        if(collision.tag == "Customer"&&hasPackage)
        {
            Debug.Log("Delivered");
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }
    }
}
