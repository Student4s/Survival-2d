using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float Speed = 10f;
    public float LifeTime = 10f;
    public float Damage = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
        LifeTime -= Time.deltaTime;
        if (LifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D Obj)
    {
        if (Obj.collider.CompareTag("Player"))
        {
            Obj.collider.GetComponent<StatsComponent>().TakeDamage(Damage);
            Destroy(gameObject);
        }
        
        if (Obj.collider.CompareTag("Enemy"))
        {
            Obj.collider.GetComponent<BasedEnemy>().TakeDamage(Damage);
            Destroy(gameObject);
        }
        
        if (Obj.collider.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
