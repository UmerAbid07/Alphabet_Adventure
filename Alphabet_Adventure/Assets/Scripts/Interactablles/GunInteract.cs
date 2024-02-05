using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInteract : Interactable
{
    public Transform player, gunContainer;
    public bool interactTriggered = false;
    Vector3 offset = new Vector3(-1.2f, 0.5f, 0f);
    private void Update()
    {
        if (interactTriggered)
        {
            transform.SetParent(gunContainer);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
        if(Input.GetKeyDown(KeyCode.Q) && interactTriggered)
        {
            transform.SetParent(null);
            transform.position = player.position + player.forward * 2;
            transform.rotation = player.rotation;
            interactTriggered = false;
        }
    }
    protected override void Interact()
    {
        interactTriggered = !interactTriggered;
        Debug.Log("Interacting with Gun");
    }
}
