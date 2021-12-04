using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchFix : MonoBehaviour
{
    public PlayerMovement player;
    [SerializeField]Vector3 startScale;
    [SerializeField]Vector3 backScale;
    void Start()
    {
        startScale.x = transform.localScale.x;
        startScale.y = transform.localScale.y * 2;
        startScale.z = transform.localScale.z;
        backScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        CrouchFix1();
    }

    void CrouchFix1()
    {
        if (player.crouching)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, startScale, Time.deltaTime * player.crouchSpeed);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, backScale, Time.deltaTime * player.crouchSpeed);
        }
    }
}
