using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public bool flag = true;
    Quaternion orgRot;


    private Vector3 dragStartPos;
    private bool isDragging = false;
    void Start()
    {
        offset = transform.localPosition;
        orgRot = transform.localRotation;
    }

    void LateUpdate()
    {


        /*if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            dragStartPos = Input.mousePosition;
            isDragging = true;
        }

        // Check for mouse button release
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Handle dragging
        if (isDragging)
        {
            Vector3 currentMousePos = Input.mousePosition;
            Vector3 dragDirection = currentMousePos - dragStartPos;

            // Normalize direction vector (optional)
            dragDirection.Normalize();

            // Calculate rotation based on drag direction
            float rotationSpeed = 5f; // Adjust as needed
            float rotationAmount = Vector3.Dot(dragDirection, Vector3.right) * rotationSpeed;

            // Apply rotation to the camera or another game object
            transform.Rotate(Vector3.up, rotationAmount, Space.World);

            // Update drag start position for next frame
            dragStartPos = currentMousePos;
        }
        
        else
        {*/
            transform.position = player.transform.position + offset;

        //}

        
        
    }
}