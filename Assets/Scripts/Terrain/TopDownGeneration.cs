using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Claims;
using UnityEngine;

public class TopDownGeneration : MonoBehaviour
{
    [SerializeField]public GameObject bckgrndtile1, bckgrndtile2;

    public Vector2 mappos = new Vector2(0,0);



    // Start is called before the first frame update
    void Start()
    {
        
        generatemap(mappos);
    }

    void generatemap(Vector2 drawpos)
    {
        GameObject BackGroundMap = Instantiate(bckgrndtile1, new Vector2(0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
