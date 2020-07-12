using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceToExplode : MonoBehaviour
{
    [SerializeField] int chance = 100;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Player"){

        
        chance = UnityEngine.Random.Range(0, 100);
        if (chance < 90)
        {
            GameObject crate = BombPool.SharedInstance.GetPooledObject();

            if (crate != null)
            {
                crate.transform.position = this.transform.position;
                crate.transform.rotation = Quaternion.identity;
                crate.SetActive(true);

            }
        }
        }
    }
}
