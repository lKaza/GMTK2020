using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovementexperimental : MonoBehaviour
{
    float rocketSpeed = 1;
    float horizontal;
    Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        


    }
}
