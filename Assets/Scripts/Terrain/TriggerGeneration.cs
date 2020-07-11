using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGeneration : MonoBehaviour
{
    [SerializeField] PlatformGeneration newMap;
    [SerializeField] ColliderPosition triggerOrientation;
    [SerializeField] GameObject crates;
    [SerializeField] int crateoffsetX = 10;
    [SerializeField] int crateoffsetY = 3;
    [SerializeField] int crateQuantity =15;

    enum ColliderPosition{
         West,North,East,South
     }

    int startPos;
    int cratecounter=0;
    bool offsetOnce=false;
    Vector3 offsetPos;
    CrateBomb bomb;
    bool side;

    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag=="Player")
        {
            cratecounter = 0;
            CheckColliderSide();

            float difference = Vector2.Distance(other.transform.position, this.transform.position);
            if (difference >= 5f)
            {
                offsetPos = new Vector3(other.transform.position.x - 15, 0);
                offsetOnce = true;
            }


            foreach (TriggerGeneration trigger in FindObjectsOfType<TriggerGeneration>())
            {

                trigger.transform.position = offsetPos;
            }
            while (cratecounter < crateQuantity)
            {
                CreateRandomCrate(other.transform);
                cratecounter++;
            }

            newMap.Generation(startPos, side);
        }

    }

    private void CheckColliderSide()
    {
        if (ColliderPosition.West == triggerOrientation)
        {
            side = false;
            startPos = newMap.GetCurrentStartNegativePos();

        }
        else if (ColliderPosition.East == triggerOrientation)
        {
            side = true;
            startPos = newMap.GetCurrentStartPositivePos();

        }
        else if (ColliderPosition.North == triggerOrientation)
        {
            startPos = newMap.GetCurrentStartPositivePos();

        }
        else if (ColliderPosition.South == triggerOrientation)
        {
            startPos = newMap.GetCurrentStartPositivePos();

        }
    }

    public void CreateRandomCrate(Transform startPosition)
    {

        float randomPosXrange = UnityEngine.Random.Range(startPosition.transform.position.x -crateoffsetX, startPosition.transform.position.x);
        float randomPosYrange = UnityEngine.Random.Range(startPosition.transform.position.y +crateoffsetY, startPosition.transform.position.y);

        GameObject crate = BombPool.SharedInstance.GetPooledObject();

        if(crate != null){
            crate.transform.position = new Vector2(randomPosXrange,randomPosYrange);
            crate.transform.rotation = Quaternion.identity;
            crate.SetActive(true);
        }

    }

}
