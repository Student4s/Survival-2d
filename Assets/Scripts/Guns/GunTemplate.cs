using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTemplate : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject ShootPoint;

    public float AmmoMax = 10f;
    public float BulletCount;
    [SerializeField]private float ammoCurrent;
    public string GunType="Semi";
    
    public float TimeBTWshoot =0.1f;
    [SerializeField]private float currentTimeBTWshoot=0f;
    
    public Transform A;
    private float Scatter = 10f;
    
    
    //Test func GetGun
    public GameObject Gun;
    void Start()
    {
        GetGun(Gun);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimeBTWshoot <= 0)
        {
            if (ammoCurrent > 0)
            {
                //for rifle, pistols, revolvers
                if (GunType == "Semi")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Instantiate(Bullet, ShootPoint.transform.position, transform.rotation);
                        currentTimeBTWshoot = TimeBTWshoot;
                        ammoCurrent -= 1;
                    }
                }

                //for automatic gun
                if (GunType == "Auto")
                {
                    if (Input.GetMouseButton(0))
                    {
                        Instantiate(Bullet, ShootPoint.transform.position, transform.rotation);
                        currentTimeBTWshoot = TimeBTWshoot;
                        ammoCurrent -= 1;
                    }
                }

                //For Shotguns
                if (GunType == "Multiple")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        for (int i = 0; i < BulletCount; i++ )
                        {
                            A.rotation = transform.rotation;
                            A.Rotate(transform.rotation.x, transform.rotation.y, Random.Range(-Scatter,Scatter));
                            Instantiate(Bullet, ShootPoint.transform.position, A.rotation);
                        }
                        currentTimeBTWshoot = TimeBTWshoot;
                        ammoCurrent -= 1;
                    }
                }

            }
            else
            {
                StartReload();
            }
        }
        else
        {
            currentTimeBTWshoot -= Time.deltaTime;
        }
    }

    public void StartReload()
    {
        ammoCurrent = AmmoMax;
    }

    public void GetGun(GameObject Gun)
    {
        Bullet = Gun.GetComponent<Gun>().Bullet;
        AmmoMax = Gun.GetComponent<Gun>().AmmoMax;
        TimeBTWshoot = Gun.GetComponent<Gun>().TimeBTWshoot;
        GunType = Gun.GetComponent<Gun>().GunType;
        BulletCount = Gun.GetComponent<Gun>().BulletCount;
        Scatter = Gun.GetComponent<Gun>().Scatter;
    }
}
