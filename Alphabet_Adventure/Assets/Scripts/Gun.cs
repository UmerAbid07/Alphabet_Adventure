using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform gunPipe;
    public ParticleSystem muzzleFlash;
    public ParticleSystem shell;
    GunInteract gunInteract;
    //public GameObject aim;
    // Start is called before the first frame update
    private void Start()
    {
        gunInteract = GetComponent<GunInteract>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") &&gunInteract.interactTriggered)
        {
            Shoot();
        }
        //transform.LookAt(aim.transform.position);
    }
    void Shoot()
    {
        muzzleFlash.Play();
        shell.Play();
        //Debug.Log("Gun clicked");
        Instantiate(bullet, gunPipe.transform.position, gunPipe.transform.rotation);
    }

}
