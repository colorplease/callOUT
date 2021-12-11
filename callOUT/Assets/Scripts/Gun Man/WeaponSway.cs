using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class WeaponSway : MonoBehaviour
{
    [Header("Sway Settings")]
    public float smooth;
    public float swayMultiplier;
    PhotonView view;

    void Start()
    {
        view = GetComponentInParent<PhotonView>();
    }
    void Update()
    {
        if (view.IsMine)
        {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;

        //calcualte target location
        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;

        //rotate
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }

    }
}
