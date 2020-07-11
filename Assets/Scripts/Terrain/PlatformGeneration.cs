using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    [SerializeField] int width;
    [SerializeField] int minHeight,maxHeight;
    [SerializeField] GameObject dirt, grass,crate,crate2;
    [SerializeField] int repeatNum;
    private int height;
    private int lastPositiveXPosition=0;
    private int lastNegativeXPosition=0;
   
    int widthIncreaseSize =0;
    int currentStartPosition;
    ContactPoint2D[] contacts = new ContactPoint2D[10];
    // Start is called before the first frame update
    private void Awake() {
       
        currentStartPosition = width;
    }
    void Start()
    {
        
        Generation(0,true);
    }

    public void Generation(int startPosition,bool side)
    {
        int repeatValue = 0;
        

        TerrainLoop(startPosition, repeatValue,CheckSide(startPosition, side));
    }

    private int CheckSide(int startPosition, bool side)
    {
        if (side)
        {
    
            lastPositiveXPosition = lastPositiveXPosition + width;
            return lastPositiveXPosition;
        }
        else
        {

            lastNegativeXPosition = lastNegativeXPosition - width;
            return lastNegativeXPosition;
        }
        
    }

    private void TerrainLoop(int startPosition, int repeatValue,int lastPosition)
    {
        if(lastPosition>0){
        for (int x = startPosition; x < lastPosition; x++)
        { //si -120 < -150
            if (repeatValue == 0)
            {
                GetRandomHeight();
                GenerateFlatPlatform(x);
                repeatValue = repeatNum;
            }
            else
            {
                GenerateFlatPlatform(x);
                repeatValue--;
            }
        }

        }else{
            for (int x = startPosition; x > lastPosition; x--)
            {
                if (repeatValue == 0)
                {
                    GetRandomHeight();
                    GenerateFlatPlatform(x);
                    repeatValue = repeatNum;
                }
                else
                {
                    GenerateFlatPlatform(x);
                    repeatValue--;
                }
        }}
    }

    private void GetRandomHeight()
    {
       
        height = UnityEngine.Random.Range(minHeight, maxHeight);
    }

    void GenerateFlatPlatform(int x)
    {
        for (int y = 0; y < height; y++)
        {
            spawnObj(dirt, x, y);
        }
        spawnObj(grass, x, height);
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
  
    void ReSpawn(){

    }
    
    public int GetCurrentStartPositivePos(){
        return lastPositiveXPosition;
    }
    public int GetCurrentStartNegativePos()
    {
        return lastNegativeXPosition;
    }
}
