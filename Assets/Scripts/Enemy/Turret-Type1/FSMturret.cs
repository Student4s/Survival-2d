using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FSMturret : MonoBehaviour
{
    private GameObject player;
    public GameObject ShootPoint;
    [SerializeField]private string currentState = "Sleep";
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        PlayerTarget.Target += Target;
    }

    public delegate void TurretShoot();
        
    public static event TurretShoot Shoot;
    void Update()
    {
        StateMachine();
    }

    void StateMachine()
    {
        switch (currentState)
        {
            case("Sleep"):
                break;
            case("Activate"):
                Activate();
                break;
            case("StartShoot"):
                StartShoot();
                break;
        }
    }

    void Activate()
    {
        Vector2 difference = player.transform.position - transform.position;
        float rotate = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0f,0f,-rotate + 270 );
        
        
        Debug.DrawRay(ShootPoint.transform.position, -transform.right*10, Color.red);
        RaycastHit2D hit= Physics2D.Raycast(ShootPoint.transform.position, -transform.right);

        if (hit.collider.CompareTag("Player"))
        {
            currentState = "StartShoot";
        }
    }

    void StartShoot()
    {
        Vector2 difference = player.transform.position - transform.position;
        float rotate = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0f,0f,-rotate + 270 );
        
        Debug.DrawRay(ShootPoint.transform.position, -transform.right*10, Color.red);
        RaycastHit2D hit= Physics2D.Raycast(ShootPoint.transform.position, -transform.right);
        
        if (hit.collider.CompareTag("Player"))
        {
            Shoot();
        }
        else
        {
            currentState="Sleep";
        }
    }
    void Target()
    {
        if (currentState == "Sleep")
        {
            currentState = "Activate";
        }
        
    }
}
