using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] float rocketVelocity=1f;
    [SerializeField] float rotationVelocity=1f;
    [SerializeField] float reduceVelocityOverTime = 2f;
    Rigidbody2D rigidBody;
    float deltaVelocity;
    Health health;
    // Start is called before the first frame update
    private void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
    }
    void Start()
    {
        
        //StartCoroutine(ReduceAngularVelocity(reduceVelocityOverTime));
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
        if(health.GetisDead()){
            z=transform.rotation.eulerAngles.z;
            SetVelocity(0);
        }else{
            z -= Input.GetAxis("Horizontal") * rotationVelocity * Time.deltaTime;
        }
       
       rot = Quaternion.Euler(0,0,z);
       transform.rotation = rot;

       Vector3 pos = transform.position;
       rigidBody.AddForce(transform.up* rocketVelocity * Time.deltaTime,ForceMode2D.Force);

       transform.position = pos;
    }


    public void SetVelocity(int amount){
        rigidBody.gravityScale = 3;
        rocketVelocity = amount;
    }
}
