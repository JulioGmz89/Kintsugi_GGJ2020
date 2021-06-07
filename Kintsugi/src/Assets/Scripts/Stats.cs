using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    //Stats

    public int currentHealth;
    public int maxHealth = 100;
    public int currentHearts;
    public int maxHearts = 4;
    public int currentGold;
    public float regenSpeed;
    private int deathTime = 5;
    public Animator animator;



    void Start()
    {
        currentHealth = maxHealth;
        currentHearts = maxHearts;
        
    }

    private void Update()
    {
        //currentHealth no puede ser mas que 100 
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        //currentHealth no puede ser mas que 100

        //Comienza trigger de funcion de morir
        if (currentHearts <= 0 | currentHealth <= 0)

        {
            animator.SetBool("IsDead", true);
            //IEnumerator processTask()
            //{
             //   yield return new WaitForSeconds(1);
            StartCoroutine(Die());
           // }

        }
        //Termina trigger de funcion de morir

        //Comienza conversion de Health a Hearts
        if(currentHealth > 0 && currentHealth 
            <= 25) { currentHearts = 1; }
        else if (currentHealth > 25 && currentHealth <= 50) { currentHearts = 2; }
        else if (currentHealth > 50 && currentHealth <= 75) { currentHearts = 3; }
        else if (currentHealth > 75 && currentHealth <= 100) { currentHearts = 4; }
        //Termina conversion de Health a Hearts



        //Comienza Trigger de Regen
        if (Input.GetButton("Fire2"))
        {
            StartCoroutine(Regen());
            

        }

        //Termina Trigger de Regen
        if (deathTime == 0)
        {
            DieReset();
        }
    }
    void FixedUpdate()
    {
        
    }
    void DieReset()
    {
        //Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(0);
    }
    public IEnumerator Die()
    {
        if (currentHealth <= 0 | currentHearts <= 0)
        {
            yield return new WaitForSeconds(1.1f);
            deathTime = 0 ;
        }
        
    
    }

    public void Damage(int damageQuantity)
    {
        this.currentHealth -= damageQuantity;

    }

    private IEnumerator Regen()
    {

        if (currentGold > 0 && currentHealth < maxHealth)
        {
            yield return new WaitForSeconds(regenSpeed);
            
            currentHealth += 1;
            currentGold -= 1;
        }
    }
}
