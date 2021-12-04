using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impact : MonoBehaviour
{
    void Awake()
    {
        Destroy(gameObject, 5f);
    }
}
