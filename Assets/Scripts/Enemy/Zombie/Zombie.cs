using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    [SerializeField] private float attackRadius;
    [SerializeField] private float damage;
    [SerializeField] private float attackSpeed;
    private float attackDellay = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        
        if (Vector2.Distance(transform.position, target.position) <= attackRadius)
        {
            if (attackDellay<=0)
            {
                Debug.Log("Zombie pucnh");
                GameObject.FindWithTag("Player").GetComponent<StatsComponent>().TakeDamage(damage);
                attackDellay = attackSpeed;
            }
        }

        attackDellay -= Time.deltaTime;
    }
    
}