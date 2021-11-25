using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuckaround : MonoBehaviour
{
    public GameObject ghostRagDoll;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Instantiate(ghostRagDoll, transform.position, transform.rotation);
        }
    }
}
