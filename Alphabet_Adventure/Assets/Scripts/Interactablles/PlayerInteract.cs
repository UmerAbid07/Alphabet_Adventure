using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float rayDistance = 3f;
    public LayerMask mask;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam= Camera.main.gameObject.GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray =new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);
        if(Physics.Raycast(ray.origin,ray.direction, out hit, rayDistance,mask))
        {
            if(hit.collider.gameObject.GetComponent<Interactable>())
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<Interactable>().baseInteract();
                    Debug.Log(hit.collider.gameObject.GetComponent<Interactable>().promptMessage);
                }
            }
        }   
        
    }
}
