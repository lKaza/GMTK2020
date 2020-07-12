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

    private void OnCollisionEnter2D(Collision2D collision)
    {
<<<<<<< HEAD
       

        //como eso?
        //
=======
        
>>>>>>> d96ba3eb0d2d29308359396e3401960e10dafc40
    }
}
