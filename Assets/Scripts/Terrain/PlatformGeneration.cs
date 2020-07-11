using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    [SerializeField] int width,height;
    [SerializeField] int minHeight,maxHeight;
    [SerializeField] GameObject dirt, grass,crate,crate2;
    [SerializeField] int repeatNum;
    
   
    int widthIncreaseSize =0;
    int currentStartPosition;
    ContactPoint2D[] contacts = new ContactPoint2D[10];
    // Start is called before the first frame update
    private void Awake() {
        widthIncreaseSize = width;
        currentStartPosition = width;
    }
    void Start()
    {
        
        Generation(0);
    }

    public void Generation(int startPosition)
    {
        int repeatValue = 0;
        if(startPosition == currentStartPosition){
            width = width+widthIncreaseSize;
            currentStartPosition = currentStartPosition+widthIncreaseSize;
        }
        for (int x = startPosition; x < width; x++)
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
  
    void ReSpawn(){

    }
    
    public int GetCurrentStartPos(){
        return currentStartPosition;
    }
}
