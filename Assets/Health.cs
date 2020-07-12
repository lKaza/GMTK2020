using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    private int currentHealth;
    bool isDead = false;

    private void Awake() {
        currentHealth = maxHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDmg(int dmg){
        currentHealth = currentHealth-dmg;
        if(currentHealth<=0 && !isDead){
            isDead= true;
            Die();
        }
    }
    public bool GetisDead (){
        return isDead;
    }

    private void Die()
    {
        // set trigger animator
        
    }
}
