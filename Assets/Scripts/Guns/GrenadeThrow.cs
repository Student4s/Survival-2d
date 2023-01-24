using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{
    public GameObject Grenade;
    public float MaxRange=1500f;
    public float Force=10f;

    private GameObject A;
    private Camera cameraMain;
    [SerializeField]private float currentRange;
    void Start()
    {
        cameraMain = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.G))
        {
            if (currentRange < MaxRange)
                currentRange += Force;
        }

        if (Input.GetKeyUp(KeyCode.G))
        {
            GameObject A = Instantiate(Grenade,transform.position,transform.rotation);
            Vector2 difference = cameraMain.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize();
            
            A.GetComponent<Grenade>().Throw(currentRange,difference);

            currentRange = 0;
        }
    }
}
