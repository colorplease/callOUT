using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KazooManAI : MonoBehaviour
{
    [SerializeField]NavMeshAgent navMeshAgent;
    [SerializeField]Transform target;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = target.position;
    }
}
