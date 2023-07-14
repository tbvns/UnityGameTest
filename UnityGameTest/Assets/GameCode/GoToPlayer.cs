using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToPlayer : MonoBehaviour
{
    public Transform Check;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = GameObject.Find("Player").transform.position;

        bool isnear = Physics.CheckSphere(Check.position, 2, mask);
        if (isnear)
        {
            Debug.Break();
        }
    }
}
