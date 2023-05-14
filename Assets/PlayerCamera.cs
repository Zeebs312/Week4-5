using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float sensX = 30f;
    public float sensY = 30f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ProcessLook(Vector2 input)
    {
        //Get mouse input
        float mouseX = input.x;
        float mouseY = input.y;
        //calculate camera rotation for looking up & down
        xRotation -= (mouseY * Time.deltaTime) * sensY;
        //Can't look more than 90 degrees
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //apply this to our camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //rotate player to look left & right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * sensX);
    }
}
