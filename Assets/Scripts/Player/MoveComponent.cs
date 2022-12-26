using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    public float Speed;//current speed
    
    private float baseSpeed;
    private float runSpeed;
    private float speedAccleretion=2.0f;
    private float staminaRunConsume=0.5f;

    private Rigidbody2D rb;
    private Camera cameraMain;
    private float offset = 90f;
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

        if (Input.GetKey(KeyCode.X)&&GetComponent<StatsComponent>().Stamina>0)
        {
            Speed = runSpeed;
            GetComponent<StatsComponent>().Stamina -= staminaRunConsume;
        }
        else
        {
            if (Speed > baseSpeed)
            {
                Speed /= 2;
            }
        }
    }
}
