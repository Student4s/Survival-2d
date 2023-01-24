using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsComponent : MonoBehaviour
{
    public float HP = 100f;
    public float Stamina = 50.0f;
    public float Energy;

    public float maxHP = 100f;
    public float maxStamina = 100f;
    public float maxEnergy = 100f;

    [SerializeField] private float exp = 0f;
    [SerializeField] private float expForLvl = 1f;
    private int currentLvl = 0;

    [SerializeField] private float water;
    [SerializeField] private float food;
    private float maxWater = 100f;
    private float maxFood = 100f;

    [SerializeField] private int Endurance;

    public delegate void HPChange(float a, float b);

    public static event StaminaChange HPChange1;

    public delegate void StaminaChange(float a, float b);

    public static event StaminaChange StaminaChange1;

    public delegate void EnergyChange(float a, float b);

    public static event EnergyChange EnergyChange1;

    public delegate void LvlChange(int lvl);

    public static event LvlChange LvlChange1;
    public delegate void SaveLoad(float HP,float Stamina, float Energy,float maxHP,float maxStamina,float maxEnergy,float exp,float expForLvl,int currentLvl,float water,float food,float maxWater,float maxFood,float Endurance, Vector3 A );

    public static event SaveLoad Save;

    void Start()
    {
        BasedEnemy.AddExp += AddEXP;
        LvlUpList.AddSomething1 += AddSkill;
        DataSaver.LoadThisShit += Load;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Stamina <= maxStamina)
        {
            Stamina += 0.1f;
            StaminaChange1(Stamina, maxStamina);
        }

        if (Energy <= maxEnergy)
        {
            Energy += 0.1f;
            EnergyChange1(Energy, maxEnergy);
        }

        Starve();
    }

    public void TakeDamage(float damage)
    {
        if (HP <= damage)
        {
            Death();
        }
        else
        {
            HP -= damage;
            HPChange1(HP, maxHP);
        }
    }

    public void MinusEnergy(float energy)
    {
        Energy -= energy;
        EnergyChange1(Energy, maxEnergy);
    }

    void AddEXP(float Exp)
    {
        exp += Exp;
        if (exp >= expForLvl)
        {
            exp -= expForLvl;
            currentLvl += 1;
            LvlChange1(currentLvl);
            expForLvl += 2;
        }
    }

    void Death()
    {
        Debug.Log("Lol, u invincible)");
    }

    public void AddEndurance(int count)
    {
        Endurance += count;
        maxStamina += count;
    }

    void AddSkill(int a)
    {
        if (a == 1)
        {
            maxHP += 10;
        }

        if (a == 2)
        {
            maxEnergy += 10;
        }
    }

    void Starve()
    {
        if (water > 0)
        {
            water -= Time.deltaTime/10;
        }
        else
        {
            TakeDamage(Time.deltaTime * 10);
        }

        if (food > 0)
        {
            food -= Time.deltaTime/10;
        }
        else
        {
            TakeDamage(Time.deltaTime * 10);
        }
    }

    public void Eat(float getFood, float getWater)
    {
        if (food + getFood < maxFood)
        {
            food += getFood;
        }
        else
        {
            food = maxFood;
        }
        
        if (water + getWater < maxWater)
        {
            water += getWater;
        }
        else
        {
            water = maxWater;
        }
    }

    public void Save1()
    {
        Vector3 A = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Save(HP,Stamina, Energy,maxHP,maxStamina,maxEnergy,exp,expForLvl,currentLvl,water,food,maxWater,maxFood, Endurance,A );
    }

    public void Load(DataSaver.Player A)
    {
        HP = A.HP;
        Stamina = A.Stamina;
        Energy = A.Energy;
        maxHP = A.maxHP;
        maxStamina = A.maxStamina;
        maxEnergy = A.maxEnergy;
        exp = A.exp;
        expForLvl = A.expForLvl;
        currentLvl = A.currentLvl;
        water = A.water;
        food = A.food;
        maxWater = A.maxWater;
        maxFood = A.maxFood;
        maxFood = A.maxFood;
        transform.position = A.Position;
    }
}