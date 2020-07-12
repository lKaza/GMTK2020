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
    [SerializeField] int boxDamage=5;

    [SerializeField] float fieldOfImpact;
    [SerializeField] float force;
    public LayerMask layerToHit;

    [SerializeField] ParticleSystem Explosion;

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

      
    }
void Update()
    {
        if (this.gameObject.activeSelf)
        {
            Invoke("DeactivateToPool", boxtime);
        }


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Explode();
            other.gameObject.GetComponent<Health>().TakeDmg(boxDamage);
            StartCoroutine(Deactivate());
            
        }

    }
  

    void Explode(){
        
        Explosion.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position,fieldOfImpact,layerToHit);
        foreach(Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction*force);
        }
        
    }
    private void OnDrawGizmosSelected() {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position,fieldOfImpact);    
    }
    IEnumerator Deactivate(){
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
    
}
