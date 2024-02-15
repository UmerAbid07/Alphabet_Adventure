using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class receptionistInterect : Interactable
{
    private Animator anim;
    private bool interactTriggered = false;
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
        interactTriggered = !interactTriggered;
        if (interactTriggered)
        {
            anim.SetBool("recept_argue", false);
        }
        else
        {
            anim.SetBool("recept_argue", true);
        }
    }
}
