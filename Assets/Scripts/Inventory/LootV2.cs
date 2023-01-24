using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootV2 : MonoBehaviour
{
    public int ID;
    public int Count;


    public static event GetLoot GetInfo;

    public delegate void GetLoot(int a, int b);

    void Get()
    {
        GetInfo(ID, Count);
    }
}
