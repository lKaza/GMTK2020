using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] int crateoffsetX = 10;
    [SerializeField] int crateoffsetY = 3;
    [SerializeField] int crateQuantity = 15;
    [SerializeField] float spawnTime=3f;

    private void Start() {
            StartCoroutine(Wait2());
            
        
    }
    IEnumerator CreateRandomCrate()
    {
        while (true)
        {
        Transform startPosition = GameObject.FindWithTag("Player").transform;
        

        for(int i =0; i<crateQuantity;i++){
                float randomPosXrange = UnityEngine.Random.Range(startPosition.transform.position.x , startPosition.transform.position.x + crateoffsetX);
                float randomPosYrange = UnityEngine.Random.Range(startPosition.transform.position.y + crateoffsetY, startPosition.transform.position.y +5);
       
        GameObject crate = BombPool.SharedInstance.GetPooledObject();

        if (crate != null)
        {
            crate.transform.position = new Vector2(randomPosXrange, randomPosYrange);
            crate.transform.rotation = Quaternion.identity;
            crate.SetActive(true);

        }
            }
        yield return new WaitForSeconds(spawnTime);
        }
    }
    IEnumerator Wait2(){
        yield return new WaitForSeconds(2f);
        StartCoroutine(CreateRandomCrate());
    }
}
