using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public float DashForce = 2000f;
    private Rigidbody2D rb;
    private Camera cameraMain;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cameraMain = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Dash();
    }

    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //float cooldown = dashCooldown
            Vector2 difference = cameraMain.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize();
            rb.AddForce(difference*DashForce);
            //skillCooldown = cooldown; 
        }
        
    }
}
