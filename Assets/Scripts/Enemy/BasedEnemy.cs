using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasedEnemy : MonoBehaviour
{
    // Standart preset for all standart enemy
    public float HP;
    public float EXP;
    public float Damage;
    public float LootIndex;// loot dropset
    public float Score;
    
    public delegate void ADDScore(float score); 
    public static event ADDScore AddScore;// add score or exp. Or exp and score
   
    
    public void TakeDamage(float damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            Death();
        }
    }
    
    virtual protected void Death()
    {
        AddScore(Score);
        Destroy(gameObject);
    }
}
