using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    public Player player;

    
    public delegate void Loader(Player A);

    public static event Loader LoadThisShit;
    private void Start()
    {
        StatsComponent.Save += NewSave;
    }

    public void LoadSave()
    {
        player = JsonUtility.FromJson<Player>(File.ReadAllText(Application.streamingAssetsPath + "/Save1.json"));
        LoadThisShit(player);
    }

     void Saved()
    {
        File.WriteAllText(Application.streamingAssetsPath + "/Save1.json", JsonUtility.ToJson(player));
    }

    public void NewSave(float HP,float Stamina, float Energy,float maxHP,float maxStamina,float maxEnergy,float exp,float expForLvl,int currentLvl,float water,float food,float maxWater,float maxFood, float Endurance,Vector3 A )
    {
        player.HP = HP;
        player.Stamina = Stamina;
        player.Energy = Energy;
        player.maxHP = maxHP;
        player.maxStamina = maxStamina;
        player.maxEnergy = maxEnergy;
        player.exp = exp;
        player.expForLvl = expForLvl;
        player.currentLvl = currentLvl;
        player.water = water;
        player.food = food;
        player.maxWater = maxWater;
        player.maxFood = maxFood;
        player.maxFood = maxFood;
        player.Position = A;

        Saved();
    }
    
    [System.Serializable]
    public class Player
    {
        public float HP=1f;
        public float Stamina =1f;
        public float Energy =1f;
        public float maxHP =1f;
        public float maxStamina =1f;
        public float maxEnergy =1f;
        
        public float exp =1f;
        public float expForLvl =1f;
        public int currentLvl =1;
        
        public float water =1f;
        public float food =1f;
        public float maxWater =1f;
        public float maxFood =1f;
        
        public float Endurance =1f;
        
        public Vector3 Position;
    }
}
