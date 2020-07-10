using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    [SerializeField] int width,height;
    [SerializeField] int minHeight,maxHeight;
    [SerializeField] GameObject dirt, grass;
    [SerializeField] int repeatNum;

    // Start is called before the first frame update
    void Start()
    {
        Generation();
    }

    private void Generation()
    {
        int repeatValue = 0;
        for (int x = 0; x < width; x++)
        {
            if(repeatValue == 0)
            {
                GetRandomHeight();
                GenerateFlatPlatform(x);
                repeatValue = repeatNum;

            }else{
                GenerateFlatPlatform(x);
                repeatValue--;
            }
            
        }
    }

    void GenerateFlatPlatform(int x)
    {
        for (int y = 0; y < height; y++)
        {

            spawnObj(dirt, x, y);

        }
        spawnObj(grass, x, height);
    }
    private void GetRandomHeight()
    {
       
        height = UnityEngine.Random.Range(minHeight, maxHeight);
    }


    // Update is called once per frame
    void Update()
    {

    }
    void spawnObj(GameObject obj, int width, int height)
    {
        obj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
        obj.transform.parent = this.transform;
       
    }
}
