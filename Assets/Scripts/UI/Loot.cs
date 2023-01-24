using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loot : MonoBehaviour
{
   [SerializeField]private GameObject text;
   [SerializeField]private int lootIndex;
   
   public delegate void LootToInvent(int index);
        
   public static event LootToInvent GetLoot;
    void Start()
    {
        text.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(true);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetLoot(lootIndex);
            Destroy(gameObject);
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(false);
        }
    }

    public void SetLootIndex(int index)
    {
        lootIndex = index;
    }

}
