using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeToInteract : Interactable
{
    Animation anim;
    Renderer color;
    private void Start()
    {
        anim = GetComponent<Animation>();
        color = GetComponent<Renderer>();
    }
    protected override void Interact()
    {
        print("intyeracted with"+gameObject.name);
        anim.Play();
        color.material.color = Color.red;
    }
    
}
