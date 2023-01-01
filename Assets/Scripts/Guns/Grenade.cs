using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float Lifetime = 3f;
    //public float force;
    
    private Rigidbody2D rb;
    private bool timer=true;
    public GameObject Explosion;

     void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer)
        {
            Lifetime -= Time.deltaTime;
        }

        if (Lifetime <= 0)
        {
            Instantiate(Explosion,transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void Throw(float force, Vector2 direction)
    {
        rb.AddForce(direction*force);
        timer = true;
    }

}
