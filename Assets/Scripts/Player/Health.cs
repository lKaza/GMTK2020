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
    public event Action<float> OnHealthPcChanged = delegate { };
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
        float currentHPPc = (float)currentHealth / (float)maxHealth;
        OnHealthPcChanged(currentHPPc);
        if(currentHealth<=0 && !isDead){
            isDead= true;
            Die();
        }
    }
    public bool GetisDead (){
        return isDead;
    }

    public int GetCurrentHealth(){
        return currentHealth;
    }
    private void Die()
    {
        // set trigger animator
        FindObjectOfType<PauseMenu>().GameOverScreen();
        
    }
}
