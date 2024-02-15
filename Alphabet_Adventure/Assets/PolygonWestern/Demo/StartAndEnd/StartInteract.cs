using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInteract : Interactable
{
    public bool interactTriggered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
        interactTriggered = !interactTriggered;
        if(interactTriggered)
        {
            Debug.Log("Mission Started!");
        }
        if(!interactTriggered)
        {
            Debug.Log("Mission Ended!");
        }
    }
}
