using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TurretGunType1 : MonoBehaviour
{
    [SerializeField]private GameObject Bullet;
    [SerializeField]private GameObject ShootPoint;
    
    [SerializeField]private float BulletCount;

    [SerializeField]private float TimeBTWshoot =0.1f;
    [SerializeField]private float currentTimeBTWshoot=0f;
    
    public Transform A;
    [SerializeField]private float Scatter = 10f;
    
    public GameObject Gun;
    void Start()
    {
        GetGun(Gun);
      
        FSMturret.Shoot += Shoot;
    }

    private void Update()
    {
        currentTimeBTWshoot -= Time.deltaTime;
    }

    void Shoot()
    {
        if (currentTimeBTWshoot <= 0)
        {
            for (int i = 0; i < BulletCount; i++ )
            {
                A.rotation = transform.rotation;
                A.Rotate(transform.rotation.x, transform.rotation.y, Random.Range(-Scatter,Scatter));
                Instantiate(Bullet, ShootPoint.transform.position, A.rotation);
            }
            currentTimeBTWshoot = TimeBTWshoot;
        }
        
    }
    
    void GetGun(GameObject Gun)
    {
        Bullet = Gun.GetComponent<GunTemplate>().Bullet;
        TimeBTWshoot = Gun.GetComponent<GunTemplate>().TimeBTWshoot;
        BulletCount = Gun.GetComponent<GunTemplate>().BulletCount;
        Scatter = Gun.GetComponent<GunTemplate>().Scatter;
    }
}
