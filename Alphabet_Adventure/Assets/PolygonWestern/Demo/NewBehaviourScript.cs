using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : Interactable
{
    private Animator anim;
    bool doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
        doorOpen = !doorOpen;
        if(doorOpen)
        {
            anim.SetBool("DoorOpen", true);
        }
        else
        {
            anim.SetBool("DoorOpen", false);
        }
        print("interacted with"+gameObject.name);    
    }
}
