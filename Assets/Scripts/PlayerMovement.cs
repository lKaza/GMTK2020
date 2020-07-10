using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]  float velocity=1f;
    [SerializeField] float acceleration = 1f;
    [SerializeField] float rocketVelocity=1f;
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
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement,0,0) * Time.deltaTime * velocity;
        rigidBody.AddForce(new Vector2(0,rocketVelocity),ForceMode2D.Impulse);
    }
}
