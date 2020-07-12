using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movebackground : MonoBehaviour
{

    public GameObject playerpos;
    Vector2 posxy = new Vector2(0, 0);

    public float altura = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(playerpos.transform.position.x,altura);
    }
}
