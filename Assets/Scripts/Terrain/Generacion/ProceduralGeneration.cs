using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] int minStoneHeight,maxStoneHeight;
    [SerializeField] GameObject dirt,grass,stone;

    // Start is called before the first frame update
    void Start()
    {
        Generation();
    }

    private void Generation()
    {
        for (int x = 0; x < width; x++)
        {
            GetRandomHeight();
            int totalSpawnDistance = GetStoneHeight(height);

            for (int y = 0; y < height; y++)
            {
                if (y < totalSpawnDistance)
                {
                    spawnObj(stone, x, y);
                }
                else
                {
                    spawnObj(dirt, x, y);
                }

            }
            spawnObj(grass, x, height);
        }
    }

    private void GetRandomHeight()
    {
        int minHeight = height - 1;
        int maxHeight = height + 2;
        height = UnityEngine.Random.Range(minHeight, maxHeight);
    }

    private int GetStoneHeight(int Randomheight)
    {
        int minStoneSpawnDistance = Randomheight - minStoneHeight;
        int maxStoneSpawnDistance = Randomheight - maxStoneHeight;
        int totalSpawnDistance = UnityEngine.Random.Range(minStoneSpawnDistance, maxStoneSpawnDistance);
        return totalSpawnDistance;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void spawnObj(GameObject obj, int width, int height){
        obj = Instantiate(obj, new Vector2(width,height), Quaternion.identity);
        obj.transform.parent = this.transform;
    }
}
