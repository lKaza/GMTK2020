using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wildrocketcontroller : MonoBehaviour
{
    // tenía que ser movement pero me equivoqué y le puse controller
    public float initialImpulse = 20;
    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.up * initialImpulse);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(transform.up * 0.1);
    }
}
