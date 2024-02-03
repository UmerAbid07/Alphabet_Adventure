using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Vector2 mousePosition;
    public Camera cam;
    private void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(mousePosition);
        transform.position = mousePosition;
    }
}
