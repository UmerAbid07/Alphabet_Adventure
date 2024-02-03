using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform gunPipe;
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        //Debug.Log("Gun clicked");
        Instantiate(bullet, gunPipe.transform.position, gunPipe.transform.rotation);
    }

}
