using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    public float Speed;//current speed
    
    public float baseSpeed;
    private float runSpeed;
    private float speedAccleretion=2.0f;
    private float staminaRunConsume=0.5f;

    private Rigidbody2D rb;
    private Camera cameraMain;
    private float offset = 90f;

    [SerializeField]private float enderanceStacked=0f;
    private float enduranceToPlus1 = 100f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        baseSpeed = Speed;
        runSpeed = Speed * speedAccleretion;
        cameraMain = Camera.main;
    }

    
    void FixedUpdate()
    {
        Vector2 difference = cameraMain.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotate = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0f,0f,-rotate + offset );
        
        Vector2 direct = new Vector2();
        direct.x = Input.GetAxis("Horizontal");
        direct.y = Input.GetAxis("Vertical");
        
        rb.AddForce(direct*Speed);
        if (direct != Vector2.zero)
        {
            enderanceStacked += Speed * Time.deltaTime;
        }

        if (enderanceStacked >= enduranceToPlus1)
        {
            gameObject.GetComponent<StatsComponent>().AddEndurance(1);
            enderanceStacked = 0f;
        }

        if (Input.GetKey(KeyCode.X)&&GetComponent<StatsComponent>().Stamina>0)
        {
            Speed = runSpeed;
            GetComponent<StatsComponent>().Stamina -= staminaRunConsume;
        }
        else
        {
            if (Speed > baseSpeed)
            {
                Speed = baseSpeed;
            }
        }
    }
}
