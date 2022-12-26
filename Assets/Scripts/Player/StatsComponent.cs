using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsComponent : MonoBehaviour
{
    public float HP;
    public float Stamina=50.0f;
    public float Energy;

    private float maxHP;
    private float maxStamina=100.0f;
    private float maxEnergy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Stamina <= maxStamina)
        {
            Stamina += 0.1f;
        }
    }
}
