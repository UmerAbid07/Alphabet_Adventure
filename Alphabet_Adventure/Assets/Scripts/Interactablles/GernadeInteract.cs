using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GernadeInteract : Interactable
{
    public bool isPick;
    public Transform gernadeContainer;
    Gernade gernade;
    Rigidbody rb;
    public float speed = 5;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gernade = GetComponent<Gernade>();
    }
    void Update()
    {
        //pick gernade
        if (isPick)
        {
            transform.SetParent(gernadeContainer);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            rb.isKinematic = true;

        }
        //drop gernade
        if (Input.GetKeyDown(KeyCode.Q) && isPick)
        {
            transform.SetParent(null);
            isPick = false;
            rb.isKinematic = false;
            rb.AddForce(gernadeContainer.forward * 3 * Time.deltaTime, ForceMode.Impulse);
        }
        //throw gernade
        if (Input.GetKeyDown(KeyCode.G) && isPick)
        {
            transform.SetParent(null);
            isPick = false;
            rb.isKinematic = false;
            rb.AddForce(gernadeContainer.forward * speed, ForceMode.Impulse);
            //gernade to exlpode
            gernade.isAboutToExploded=true;
            print("Explode function called");
        }
    }
    protected override void Interact()
    {
        print("Interacting with Gernade");
        isPick=!isPick;
    }
    // Update is called once per frame
    
}
