using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    public GameObject Hero;
    public float Dumping;
    
    void Update()
    {
        Vector2 NewPosition =  Vector3.Lerp(transform.position, Hero.transform.position, Dumping * Time.deltaTime);
        transform.position = new Vector3(NewPosition.x, NewPosition.y, transform.position.z);
    }
}
