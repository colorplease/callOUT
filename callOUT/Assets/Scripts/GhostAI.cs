using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour
{
    public Transform player;
    public float HP = 100f;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Vacuum Man").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.position, transform.up);
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * 0.01f);
    }
}
