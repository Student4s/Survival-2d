using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryV2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LootV2.GetInfo += GetLoot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetLoot(int id, int count)
    {
        Debug.Log("Done1");
    }
}
