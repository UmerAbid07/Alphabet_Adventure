using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helath : MonoBehaviour
{
    //Payer Heath
    public float heath = 100;
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            print("Hit");
            heath -= 10;
            if (heath <= 0)
            {
                //diable player controller and show game over screen
                Debug.Log("Game Over");
                playerController.enabled = false;
            }
        }
    }
}
