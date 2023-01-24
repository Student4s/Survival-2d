using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvlmanager : MonoBehaviour
{
    public GameObject[] Levels;
    void Start()
    {
        for (int i=0; i<Levels.Length; i++)
        {
            Levels[i].SetActive(false);
        }
        
        Levels[0].SetActive(true);

        TelepBtwLvl.TeleportLvl += SetLevels;
    }

    public void SetLevels(int lvlNumber)
    {
        for (int i=0; i<Levels.Length; i++)
        {
            Levels[i].SetActive(false);
        }
        
        Levels[lvlNumber].SetActive(true);
    }
}
