using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelepBtwLvl : MonoBehaviour
{
    [SerializeField] private GameObject destinationPoint;
    [SerializeField] private GameObject PlayerCamera;
    [SerializeField] private int LvlNumber;

    public delegate void Telep(int a);

    public static event Telep TeleportLvl;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           Vector2 A = new Vector2(destinationPoint.transform.position.x, destinationPoint.transform.position.y);
           other.transform.position = A;
            PlayerCamera.transform.position = A;
            TeleportLvl(LvlNumber);
        }
    }
}
