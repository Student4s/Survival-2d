using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   [SerializeField] private float res1;//zombie meat
   [SerializeField] private float res2;//Electronic components
   [SerializeField] private float res3;
   [SerializeField] private float res4;
   [SerializeField] private float res5;
   [SerializeField] private float res6;
   [SerializeField] private float res7;//Metal Scrap
   void Start()
    {
        Loot.GetLoot += GetLoot;
        Metalscrap.GetMetal += GetLoot;
    }

    void GetLoot(int lootIndex)
    {
        if (lootIndex == 0) //zombie
        {
            res1 += Random.Range(1, 3);
        }
        
        if (lootIndex == 1) //turret
        {
            res2 += Random.Range(1, 3);
        }

        if (lootIndex == 7) //Metal scrap
        {
            res7 += 1;
        }
    }
}
