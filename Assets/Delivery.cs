using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float destroyDelay = 1f;

    [SerializeField] Color32 hasPackageColor = new Color32(16, 195, 18, 255);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    
    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
     void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("OUCH... That hurt!");
    }

    void OnTriggerEnter2D(Collider2D other) {
            if(other.tag == "Package" && !hasPackage) 
            {
                Debug.Log("Package picked up!");
                hasPackage = true;
                spriteRenderer.color = hasPackageColor;
                Destroy(other.gameObject, destroyDelay);
            } else if (other.tag == "Customer" && hasPackage) 
            {
                Debug.Log("Package delivered!");
                hasPackage = false;
                spriteRenderer.color = noPackageColor;
            }
    }
}

