using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10f;
    public float LifeTime = 10f;
    public float Damage = 1f;

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
        LifeTime -= Time.deltaTime;
        if (LifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D Obj)
    {
        if (Obj.collider.CompareTag("Enemy"))
        {
            Obj.collider.GetComponent<BasedEnemy>().TakeDamage(Damage);
            Destroy(gameObject);
        }

        Debug.Log("Touch");
        if (Obj.collider.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}