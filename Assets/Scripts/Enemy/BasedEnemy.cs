using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasedEnemy : MonoBehaviour
{
    // Standart preset for all standart enemy
    public float HP;
    public float EXP;
    public int LootIndex=5;// loot dropset
    public GameObject loot;
    [SerializeField] private GameObject WordlCanvas;

    public delegate void ADDScore(float score); 
    public static event ADDScore AddExp;
    
    //public delegate void NPCdeath(int  index, Transform position); 
    //public static event NPCdeath SpawnLoot;
   
    
    public void TakeDamage(float damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            Death();
        }
    }
    
    void Death()
    {
        GameObject A = Instantiate(loot, transform.position, Quaternion.Euler(0,0,0));
        A.GetComponent<Loot>().SetLootIndex(LootIndex);
        A.transform.parent = WordlCanvas.transform;
        Debug.Log("Death");
        AddExp(EXP);
        Destroy(gameObject);
    }
}
