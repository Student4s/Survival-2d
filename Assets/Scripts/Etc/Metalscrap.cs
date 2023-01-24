using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metalscrap : MonoBehaviour
{
    [SerializeField]private GameObject text;
    [SerializeField]private GameObject worldCanvas;
    [SerializeField]private int lootCount;
    [SerializeField]private bool canHarvest;
    [SerializeField]private float harvestSpeed=1f;
    private float currentHarvest=0f;
    private int lootIndex=7;

    private GameObject player;
    
    public delegate void Harvest(int index);
        
    public static event Harvest GetMetal;
    void Start()
    {
        transform.parent = worldCanvas.transform;
        text.SetActive(false);
        canHarvest = false;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (canHarvest && Input.GetKey(KeyCode.T)&&lootCount>=1&&player.GetComponent<StatsComponent>().Stamina>0)
        {
            currentHarvest += Time.deltaTime;
            player.GetComponent<StatsComponent>().Stamina -= Time.deltaTime*10;
        }

        if (currentHarvest >= harvestSpeed)
        {
            currentHarvest = 0;
            lootCount -= 1;
            GetMetal(lootIndex);
            if (lootCount <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(true);
            canHarvest = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(false);
            canHarvest = false;
        }
    }

}
