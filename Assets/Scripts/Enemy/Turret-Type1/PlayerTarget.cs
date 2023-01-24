using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    [SerializeField]private GameObject player;

    public delegate void TargetPlayer();
        
    public static event TargetPlayer Target;
    void Start()
    {
        player = GameObject.FindWithTag("Player");

    }
    
    void Update()
    {
        Vector2 difference = player.transform.position - transform.position;
        float rotate = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0f,0f,-rotate + 270 );
        
        Debug.DrawRay(gameObject.transform.position, -transform.right*10, Color.yellow);
        RaycastHit2D hit= Physics2D.Raycast(gameObject.transform.position, -transform.right);

        if (hit.collider.CompareTag("Player"))
        {
            //Debug.Log("Target!");
            Target();

        }
    }
}
