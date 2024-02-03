using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //FPS Controller
    Camera fpsCam;
    float horizontalInput;
    float vertiaclInput;
    public float speed = 5.0f;
    public float jumpForce = 1.5f;
    CharacterController cc;
    float mouseX;
    float mouseY;
    public float xMouseSensitivity = 30;
    public float yMouseSensitivity = 30;
    float xRotation;
    float gravity = -9.81f;
    public float downvelocity = 0;
    public bool isCrouching = false;
    static bool isSprinting = true;
    public bool spceKeyPressed;
    // Start is called before the first frame update
    void Start()
    {
        //Get the camera component
        fpsCam = GetComponentInChildren<Camera>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        spceKeyPressed= Input.GetKey(KeyCode.LeftShift);
        
        //Keyboard Inputs
        horizontalInput = Input.GetAxis("Horizontal");
        vertiaclInput = Input.GetAxis("Vertical");
        //Mouse Inputs
        mouseX=Input.GetAxis("Mouse X");
        mouseY=Input.GetAxis("Mouse Y");
        downvelocity += gravity * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        //Move the player
        cc.Move(transform.forward * vertiaclInput * speed * Time.deltaTime);
        cc.Move(transform.right * horizontalInput * speed * Time.deltaTime);
        
        //move Camera at mouse position as well as clamp the rotation at x axis
        xRotation -= (mouseY * Time.deltaTime) * yMouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -80, 80);
        fpsCam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //rotate the player
        transform.Rotate(Vector3.up * mouseX * xMouseSensitivity * Time.deltaTime);

        //gravity
        cc.Move(Vector3.up * downvelocity * Time.deltaTime);
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded)
        {
            downvelocity=Mathf.Sqrt(jumpForce * -2 * gravity);
        }
        crouch();
        sprint();
        
        speed = isSprinting ? 10.0f : 5.0f;
        //if isSprinting=true then start a timer and decrease the timer by 1 every second as a stamina
        //if the timer is less than 0 then isSprinting=false
        
    }
    float timer = 5;
    void crouch()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching= !isCrouching;
            cc.height = isCrouching ? 1.0f : 2.0f;
        }
    }
    void sprint()
    {
        if (spceKeyPressed && timer >= 0)
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
            //timer = 5;
        }
        stamina();
    }
    void stamina()
    {
        if (isSprinting)
        {

            timer -= Time.deltaTime;
            print(timer);
            if (timer <= 0)
            {
                isSprinting = false;
                //print(isSprinting);
            }
        }
        reGainStamina();
    }
    void reGainStamina()
    {
        if(!isSprinting)
        {
            timer += Time.deltaTime;
            if (timer >= 5)
            {
                timer = 5;
            }
            //print(timer);
        }
    }

}
