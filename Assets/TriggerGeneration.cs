using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGeneration : MonoBehaviour
{
    [SerializeField] PlatformGeneration newMap;
    private void OnTriggerEnter2D(Collider2D other) {
        
        int startPos = newMap.GetCurrentStartPos();
        newMap.Generation(startPos);
        Vector3 newPos = new Vector3(startPos,0);
        foreach(TriggerGeneration trigger in FindObjectsOfType<TriggerGeneration>()){
            trigger.transform.position = newPos;
        }
        
    }

}
