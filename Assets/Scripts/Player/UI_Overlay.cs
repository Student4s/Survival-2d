using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Overlay : MonoBehaviour
{
    
    public Image Stamina;
    public Image HP;
    public Image Energy;
    public Text LVL;
    void Start()
    {
        StatsComponent.StaminaChange1 += StaminaChange;
        StatsComponent.HPChange1 += HPChange;
        StatsComponent.EnergyChange1 += EnergyChange;
        StatsComponent.LvlChange1 += LvlChange;
    }
    

    void StaminaChange(float stamina, float staminaMax)
    {
        float fill = stamina / staminaMax;
        Stamina.fillAmount = fill;
    }

    void LvlChange(int lvl)
    {
        LVL.text = ""+lvl;
    }
    void HPChange(float hp, float hpMax)
    {
        float fill = hp / hpMax;
        HP.fillAmount = fill;
    }
    
    void EnergyChange(float energy, float maxEnergy)
    {
        float fill = energy / maxEnergy;
        Energy.fillAmount = fill;
    }
}
