using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KazooManAI : MonoBehaviour
{
    [SerializeField]NavMeshAgent navMeshAgent;
    [SerializeField]Transform target;
    [SerializeField]GameObject ragDoll;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = target.position;

        if (health <= 0)
        {
            Instantiate(ragDoll, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Slope")
        {
            navMeshAgent.speed = 10;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Slope")
        {
            navMeshAgent.speed = 2.5f;
        }
    }
}
