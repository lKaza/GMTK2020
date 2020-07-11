using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGeneration : MonoBehaviour
{
    [SerializeField] PlatformGeneration newMap;
    [SerializeField] GameObject crates;
    [SerializeField] int crateoffsetX =10;
    [SerializeField] int crateoffsetY = 3;
    [SerializeField] int crateQuantity =15;
    int cratecounter=0;
    bool offsetOnce=false;
    Vector3 offsetPos;
    CrateBomb bomb;

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag=="Player"){
            cratecounter = 0;
        int startPos = newMap.GetCurrentStartPos();
           if(!offsetOnce){
                offsetPos = new Vector3(other.transform.position.x - 1, 0);
                offsetOnce=true;
           }
            offsetPos = new Vector3(other.transform.position.x, 0);
            
            foreach (TriggerGeneration trigger in FindObjectsOfType<TriggerGeneration>())
            {   

                trigger.transform.position = offsetPos;
        }   
            while(cratecounter<crateQuantity){
                CreateRandomCrate(other.transform);
                cratecounter++;
            }
          
            newMap.Generation(startPos);
        }
        
    }
    public void CreateRandomCrate(Transform startPosition)
    {

        float randomPosXrange = UnityEngine.Random.Range(startPosition.transform.position.x -crateoffsetX, startPosition.transform.position.x);
        float randomPosYrange = UnityEngine.Random.Range(startPosition.transform.position.y +crateoffsetY, startPosition.transform.position.y);
        GameObject obj = Instantiate(crates, new Vector2(randomPosXrange, randomPosYrange), Quaternion.identity);

    }

}
