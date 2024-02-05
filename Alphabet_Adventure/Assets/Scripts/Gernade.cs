using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gernade : MonoBehaviour
{
    Rigidbody rb;
    public float explosionForce = 1000;
    public float explosionRadius = 15;
    public bool isAboutToExploded;
    float timer = 3f;
    public GameObject explosiveEffect;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(isAboutToExploded)
        {
            //explode gernade
            //Destroy(gameObject);
            timer -= Time.deltaTime;
            print("Timer: " + timer);
            if (timer <= 0)
            {
                Collider[] collider= Physics.OverlapSphere(transform.position, explosionRadius);
                foreach(Collider nearByObject in collider)
                {
                    Rigidbody rb = nearByObject.GetComponent<Rigidbody>();
                    if(rb)
                    {
                        rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                    }
                }
                Instantiate(explosiveEffect, transform.position, Quaternion.identity);
                Destroy(explosiveEffect, 2f);
                print("Exploded");
                Destroy(gameObject);
            }
        }
    }
}
