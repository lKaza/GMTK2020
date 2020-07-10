﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] float rocketVelocity=1f;
    [SerializeField] float rotationVelocity=1f;
    Rigidbody2D rigidBody;
    // Start is called before the first frame update
    private void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       PMovement();


    }
    void PMovement()
    {
        
       Quaternion rot = transform.rotation;
       float z = rot.eulerAngles.z;

       z -= Input.GetAxis("Horizontal") * rotationVelocity * Time.deltaTime;
       rot = Quaternion.Euler(0,0,z);
       transform.rotation = rot;

       Vector3 pos = transform.position;
       rigidBody.AddForce(transform.up* rocketVelocity * Time.deltaTime,ForceMode2D.Force);
       
       transform.position = pos;


    }
}