using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DataBase;
public class InventoryCell : MonoBehaviour
{
    public int Count=0;
    public int MaxCount = 1;

    public int ID=0;

    public Sprite Img;

    void Start()
    {
        MaxCount = Database.GetMaxCount(ID);
    }
}
