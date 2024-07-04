using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float moveSpeed = 5f;
    private float rotationSpeed = 5f;
    public GameObject camera;
    private Quaternion rotation;


    //public UserTypeHandler userTypeHandler;

     public void doYourJob()
    {
        //userTypeHandler.StartFetchingUserInput();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }


    void FixedUpdate()
    {
        float horizontalSignal = Input.GetAxis("Horizontal");
        float verticalSignal = Input.GetAxis("Vertical");
        rotation = camera.GetComponent<Transform>().rotation;
        //transform.rotation.SetAxisAngle(Vector3.up, rotation.y);
        transform.rotation = rotation;
        if (Mathf.Abs(horizontalSignal) > .2f)
        {
            transform.Translate(Vector3.right * moveSpeed * horizontalSignal * Time.deltaTime);
        }
        if (Mathf.Abs(verticalSignal) > .2f)

            transform.Translate(Vector3.forward * moveSpeed * verticalSignal * Time.deltaTime);

    }




}