using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ballbomb : MonoBehaviour
{
    [SerializeField] public float initialForce = 10;
    Rigidbody2D rigidbody;

    public GameObject explosion;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.right * initialForce);
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision collision)
    {
        
    }
}
