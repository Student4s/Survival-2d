using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera cameraMain;

    [SerializeField] private float dashForce = 2000f;
    private float dashEnergyCost = 10f;
    private bool isDashActive = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cameraMain = Camera.main;
        LvlUpList.AddSomething1 += AddSkill;
    }
    
    void Update()
    {
        Dash();
        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(TimeStopper());
        }
    }

    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Z)&&isDashActive)
        {
            if (gameObject.GetComponent<StatsComponent>().Energy >= dashEnergyCost)
            {
                Vector2 difference = cameraMain.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                difference.Normalize();
                rb.AddForce(difference * dashForce);
                gameObject.GetComponent<StatsComponent>().MinusEnergy(dashEnergyCost);
            }
        }
    }

    public void DashActivate()
    {
        isDashActive = true;
    }
    public IEnumerator TimeStopper()
    {
            Time.timeScale = 0.5f;
            Debug.Log("StartCourutine");

            yield return new WaitForSeconds(2f);
            
            Time.timeScale = 1f;
            Debug.Log("EndCourutine");
            
    }

    void AddSkill(int a)
    {
        if (a == 3)
        {
            isDashActive = true;
        }
    }
}
