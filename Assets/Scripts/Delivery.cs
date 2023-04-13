using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
 
    [SerializeField] List<GameObject> packages;
    private GameObject currentPackage;
    private SpriteRenderer spriteRenderer;
    private bool isPackagePickedUp;

    private void Start() {
        currentPackage = null;
        isPackagePickedUp = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnCollisionEnter2D(Collision2D other) {
        // Debug.Log("Ouch!");
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !isPackagePickedUp) {
            isPackagePickedUp = true;
            currentPackage = other.gameObject;
            spriteRenderer.color = hasPackageColor;
            Destroy(currentPackage, 0.5f);
        }
        if(other.tag == "Customer" && isPackagePickedUp) {
            spriteRenderer.color = noPackageColor;
            packages.Remove(currentPackage);
            isPackagePickedUp = false;
            if(packages.Count == 0) {
                Debug.Log("WOW, YOU'VE DELIVERED ALL THE PACKAGES!");
            }
        }
    }
}
