using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBomb : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rigidbody2D;
    float boxspeed;
    public float boxtime = 5;
    public float boxforce = 1;
    Vector2 boxinercy = new Vector2(0,1);
    public float maxangl;
    public float minangl;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        var boxrotation = transform.rotation;

        boxrotation.z = UnityEngine.Random.Range(minangl, maxangl);
        
        transform.rotation = boxrotation;

        rigidbody2D.AddForce(transform.up * boxforce, ForceMode2D.Impulse);

        Destroy(gameObject, boxtime);
    }

    // Update is called once per frame
    void Update()
    {
      
            
              
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Player"){
            Destroy(gameObject);
        }
        
    }

    
}
