using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class LvlUpList : MonoBehaviour
{
    private int skillPoint = 1;
    [SerializeField] private Text txt;

    private bool isActiveImage=false;
    [SerializeField]private GameObject background;
    
    
    public delegate void AddSomething(int a);
    public static event AddSomething AddSomething1;
    
    private void Start()
    {
        StatsComponent.LvlChange1 += AddSkillpoint;
        UpdateSkillPoint();
        background.SetActive(isActiveImage);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isActiveImage = !isActiveImage;
            background.SetActive(isActiveImage);
        }
    }

    public void AddHP()
    {
        if (skillPoint >= 1)
        {
            AddSomething1(1);
            skillPoint -= 1;
            UpdateSkillPoint();
        }
        
    }
    public void AddEnergy()
    {
        if (skillPoint >= 1)
        {
            AddSomething1(2);
            skillPoint -= 1;
            UpdateSkillPoint();
        }
    }
    public void AddDash()
    {
        if (skillPoint >= 1)
        {
            AddSomething1(3);
            skillPoint -= 1;
            UpdateSkillPoint();
        }
    }
    
    public void AddSkillpoint(int a)
    {
        skillPoint += 1;
        UpdateSkillPoint();
    }

    void UpdateSkillPoint()
    {
        txt.text = "Очков умений:" + skillPoint;
    }
}
