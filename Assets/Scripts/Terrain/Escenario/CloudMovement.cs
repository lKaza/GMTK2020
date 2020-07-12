using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{

    //Marco de generación
    [SerializeField]  Vector2 boxcloudpos = new Vector2(0,0);
    
    [SerializeField]  float height = 15;
    [SerializeField]  float length = 10 ;
    [SerializeField]  float rightdistance;
    [SerializeField]  float leftdistance;
    [SerializeField]  float clouddistance = 20;
    [SerializeField]  GameObject player;
    float totalcloud;

    public GameObject cloudcontainer;
    public GameObject[] cloudcontainerarray;

    [SerializeField] float cloudspeed;

    Vector2 playerpos;
    Vector2 cloudpos;

    void Start()
    {
        cloudstart();
    }

    void Update()
    {
        
        playerpos = player.transform.position;
        //boxcalculator();
        icloudcalc();//independient cloud calculator
        clouddisplacement();
    }

    void clouddisplacement()
    {
        for(int i = 0; i <= totalcloud; i++)
        {
            cloudcontainerarray[i].transform.position = new Vector2((cloudcontainerarray[i].transform.position.x - (cloudspeed / 200)), cloudcontainerarray[i].transform.position.y); 
        }
    }
    void icloudcalc()
    {
        for(int i = 0; i <= totalcloud; i++){
            if (cloudcontainerarray[i].gameObject.transform.position.x < (playerpos.x - clouddistance))
            {
                cloudcontainerarray[i].transform.position = new Vector2(player.transform.position.x + clouddistance + Random.Range(-2,10), player.transform.position.y + Random.Range(-6,15));
            }
        }
        

        /*
         * for(int i = 0; i <= totalcloud; i++)
        {
            if(cloudcontainerarray[i].gameObject.transform.position.x < leftdistance)
            {
                transform.position = new Vector2(cloudcontainerarray[i].gameObject.transform.position.x + length, 0);
            }
        }
         */
    }
    void cloudstart()
    {
        cloudcontainer = GameObject.Find("cloudscontainer");
       
        cloudfinder();

        leftdistance = 0;
        rightdistance = length;
    }
    
    //
    void boxcalculator() {
        if (playerpos.x >= (rightdistance - 1))
        {
            boxcloudpos.x = boxcloudpos.x + 1;
            leftdistance = rightdistance;
            rightdistance = length * boxcloudpos.x;

            generatecloud();
        }
    }
    void cloudfinder()
    {
        totalcloud = 0;
        cloudcontainerarray = GameObject.FindGameObjectsWithTag("BackgroundCloud");
        for(int i = 0; i < cloudcontainerarray.Length; i++)
        {
            cloudcontainerarray[i].gameObject.transform.parent = cloudcontainer.transform;
            cloudcontainerarray[i].gameObject.SetActive(true);
            cloudcontainerarray[i].gameObject.name = "CloudID:" + i;
            totalcloud = i;
        }
    }
    void generatecloud()
    {
        for(int i = 0; i <= totalcloud; i++)
        {
            if(cloudcontainerarray[i].gameObject.transform.position.x < leftdistance)
            {
                transform.position = new Vector2(cloudcontainerarray[i].gameObject.transform.position.x + length, 0);
            }
        }
    }


    
}
