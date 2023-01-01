using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasetTut : MonoBehaviour
{
    public Camera Cam;
    public LineRenderer LR;
    public Transform ShootPoint;

    public GameObject StartVFX;
    public GameObject EndVFX;

    private Quaternion rotation;
    private List<ParticleSystem> particles= new List<ParticleSystem>();
    void Start()
    {
        FillList();
        DisableLaser();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EnebleLaser();
        }
        
        if (Input.GetMouseButton(0))
        {
            UpdateLaser();
        }
        if (Input.GetMouseButtonUp(0))
        {
            DisableLaser();
        }
    }

    void EnebleLaser()
    {
        LR.enabled = true;

        for (int i = 0; i < particles.Count; i++)
        {
            particles[i].Play();
        }
    }
    void UpdateLaser()
    {
        var mousePos = (Vector2)Cam.ScreenToWorldPoint(Input.mousePosition);
        LR.SetPosition(0, ShootPoint.position);
        StartVFX.transform.position = ShootPoint.position;
        LR.SetPosition(1,mousePos );

        Vector2 direction = mousePos - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2) transform.position, direction.normalized,direction.magnitude);

        if (hit)
        {
            LR.SetPosition(1,hit.point);
        }
        EndVFX.transform.position = LR.GetPosition(1);
    }
    void DisableLaser()
    {
        LR.enabled = false;
        for (int i = 0; i < particles.Count; i++)
        {
            particles[i].Stop();
        }
    }

    void FillList()
    {
        for (int i = 0; i < StartVFX.transform.childCount - 1; i++)
        {
            var ps = StartVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null)
            {
                particles.Add(ps);
            }
        }
        
        for (int i = 0; i < EndVFX.transform.childCount - 1; i++)
        {
            var ps = EndVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null)
            {
                particles.Add(ps);
            }
        }
    }
}
